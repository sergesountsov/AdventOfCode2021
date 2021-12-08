string? line;
int result =0;
while ((line = Console.ReadLine())!=null) {
    var parts = line.Split(" | ");
    var outputs = parts[1].Split(' ');
    foreach (var o in outputs) {
        if (o.Length == 2 || o.Length ==3 ||o.Length ==4 || o.Length == 7) {
            result++;
        }
    }
}

Console.WriteLine($"Part1 result: {result} ");