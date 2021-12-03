string? line;
int distance = 0;
int depth = 0 ;
int aim =0;

while ((line = Console.ReadLine()) != null) {
    string[] parts = line.Split(" ");
    int arg = int.Parse(parts[1]);
    switch (parts[0]) {
        case "up": aim -= arg; break;
        case "down": aim += arg; break;
        case "forward": distance += arg; depth+=aim*arg; break;
        default: throw new ArgumentException($"Unexpected command {parts[0]}"); 

    }
}

Console.WriteLine ("distance: {0}, depth: {1}, answer: {2}", distance, depth, distance*depth);
