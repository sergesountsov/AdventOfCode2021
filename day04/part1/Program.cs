using (var sr = File.OpenText("input.txt")) {
    var plays = sr.ReadLine().Split(",").Select((s) => int.Parse(s) ).ToList();
    Console.WriteLine("Read {0} plays", plays.Count);

    List<Board> boards = new ();
    while (sr.Peek() != -1) {
        sr.ReadLine();        
        boards.Add(new Board(sr));
    }
    Console.WriteLine($"Read {boards.Count} boards");
    foreach (var play in plays) {
        foreach (var board in boards) {
            if (board.Mark(play)) {
                var score = board.Score();
                Console.WriteLine ($"Board score: {score}, play: {play}, result: {score*play}");
                return;
            }
        }
    }
}