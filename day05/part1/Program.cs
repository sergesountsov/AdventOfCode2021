using System.Text.RegularExpressions;

int maxX=0, maxY=0;
List<Line> input = new();

using (var sr = File.OpenText("input.txt")) {
    Regex re = new Regex(@"(\d+),(\d+) -> (\d+),(\d+)");
    while (sr.Peek() != -1 ) {
        var line = sr.ReadLine();
        var m = re.Match(line);
        Line l = new Line(int.Parse(m.Groups[1].Value), 
            int.Parse(m.Groups[2].Value),
            int.Parse(m.Groups[3].Value),
            int.Parse(m.Groups[4].Value)
        );
        maxX=Math.Max(maxX, Math.Max(l.X1, l.X2));
        maxY=Math.Max(maxY, Math.Max(l.Y1, l.Y2));
        input.Add(l);
    }
}

var field1 = DrawField(maxX, maxY, input, false);
// PrintField(field1);
// Console.WriteLine("----");
var field2 = DrawField(maxX, maxY, input, true);
// PrintField(field2);
Console.WriteLine($"Part 1 result: {Result(field1)}");
Console.WriteLine($"Part 2 result: {Result(field2)}");

void PrintField(int[,] field2) {
    for(int y = 0; y<field2.GetLength(1); y++ ) {
        for(int x = 0; x < field2.GetLength(0); x++) {
            Console.Write(field2[x,y]);
        }
        Console.WriteLine();
    }
}

int [,] DrawField(int maxX, int maxY, List<Line> input,bool doDiagonals) {
    int[,] field = new int[maxX+1,maxY+1];
    Console.WriteLine($"maxX: {maxX}, maxY: {maxY}");
    foreach (var line in input) {

        if (line.X1 == line.X2) { //vertical
            for (int y = Math.Min(line.Y1, line.Y2); y <= Math.Max(line.Y1, line.Y2); y++) {
                field[line.X1,y]++;
            }
            
        } else if (line.Y1 == line.Y2 ) { // horizontal
            for (int x = Math.Min(line.X1, line.X2); x <= Math.Max(line.X1, line.X2); x++ ) {
                field[x,line.Y1]++;
            }
        } else if (doDiagonals ) { // do diagonals for part 2
            int startX = 0;
            int startY = 0;
            int yDirection = 1;
            if (line.X1 < line.X2) {
                startX = line.X1;
                startY = line.Y1;
                if (line.Y1 > line.Y2) {
                    yDirection = -1;
                }
            } else {
                startX = line.X2;
                startY = line.Y2;
                if (line.Y2 > line.Y1) {
                    yDirection = -1;
                }

            }

            for (int i = 0; i <= Math.Abs(line.X1-line.X2); i++) {
                field[startX+i,startY+(i*yDirection)]++;
            }
        }

    }
    return field;
}

int Result(int[,] field ) {
    int result =0;
    for (int x =0; x < field.GetLength(0); x++) {
        for (int y = 0; y < field.GetLength(1); y++) {
            if (field[x,y]>1) {
                result++;
            }
        }
    }
    return result;
}