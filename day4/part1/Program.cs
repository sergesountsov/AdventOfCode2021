using (var sr = File.OpenText("input.txt")) {
    var plays = sr.ReadLine().Split(",").Select((s) => int.Parse(s) ).ToList();
    Console.WriteLine("Read {0} plays", plays.Count);

    List<Board> boards = new ();
    while (sr.Peek() != -1) {
        sr.ReadLine();        
        boards.Add(new Board(sr));
    }
}