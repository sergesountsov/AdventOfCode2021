
int FindResult (Func<string[], string[], int> decode) {
    string? line;
    int result =0;
    while ((line = Console.ReadLine())!=null) {
        var parts = line.Split(" | ");
        var outputs = parts[1].Split(' ');
        result += decode(parts[0].Split(' '), parts[1].Split(' '));
    }
    return result;
}

int Part1Decode (string[] segments, string[] outputs) {
    int result =0;
    foreach (var o in outputs) {
        if (o.Length == 2 || o.Length ==3 ||o.Length ==4 || o.Length == 7) {
            result++;
        }
    }
    return result;
}
Console.WriteLine($"Part1 result: {FindResult(Part1Decode)}");