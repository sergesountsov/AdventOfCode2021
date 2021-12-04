using (var sr = File.OpenText("input.txt")) {
    var plays = sr.ReadLine().Split(",").Select((s) => int.Parse(s) ).ToList();
    Console.WriteLine("Read {0} plays", plays.Count);

    List<Board> boards = new ();
    while (sr.Peek() != -1) {
        sr.ReadLine();        
        boards.Add(new Board(sr));
    }
    Console.WriteLine($"Read {boards.Count} boards");
    Board first = null;
    Board last = null;
    int lastPlay=0;
    foreach (var play in plays) {
        foreach (var board in boards) {
            if (board.Done)
                continue;

            if (board.Mark(play)) {
                if (first == null ) {
                    first = board;
                    Console.WriteLine ($"First Board score: {first.Score()}, play: {play}, PART 1 result: {first.Score()*play}");
                }
                last = board;
                lastPlay = play;
            }
        }
    }
    Console.WriteLine ($"Last Board score: {last.Score()}, play: {lastPlay}, PART 2 result: {last.Score()*lastPlay}");
 
}