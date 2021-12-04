public class Board {
    private int[,] numbers = new int[5,5];
    private bool[,] marked = new bool[5,5];

    public Board(StreamReader sr) {
        Read(sr);
    }
    public void Read (StreamReader sr) {
        for (int row =0; row <5; row++) {
            string[] line = (sr.ReadLine()).Split(" ");
            for (int col =0; col < 5; col++ ) {
                numbers[row,col] = int.Parse(line[col]);
                marked[row,col]=false;
            }
        }
    }

    public bool Mark(int candidate) {
        for(int row =0; row < numbers.GetLength(0); row++){
            for (int col=0; col < numbers.GetLength(1); col++){
                if (numbers[row,col] == candidate) {
                    marked[row,col] = true;
                    return Check(row,col);
                }
            }
        }
        return false;
    }

    public bool Check(int cr, int cc) {
        bool hasUnmarked = false;
        for(int row =0; row < marked.GetLength(0); row++) {
            if (!marked[row, cc]) {
                hasUnmarked = true;
                break;
            }
        }
        if (!hasUnmarked) return true;

        for (int col=0; col <marked.GetLength(1); col ++) {
            if (!marked[cr, col]) {
                return false;
            }
        }
        return true;
    }

    public int Score() {
        int score = 0;
        for (int row=0; row < marked.GetLength(0); row ++) {
            for (int col=0; col < marked.GetLength(1); col++) {
                if (!marked[row,col]) {
                    score+=numbers[row,col];
                }
            }
        }
        return score;
    }
}