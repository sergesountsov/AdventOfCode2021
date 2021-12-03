string? line;
int[] count_1 = new int[12];
int lines = 0;

while ((line = Console.ReadLine())!= null) {
    for (int i =0; i<line.Length; i++) {
        if (line[i] == '1') {
            count_1[i]++;
        }
    }
    lines++;
}

Console.WriteLine("Count: {0}\nlines: {1}", string.Join(",",count_1), lines);
int half_lines = lines/2;
int gamma = 0; 
int epsilon = 0;

foreach (var cnt in count_1) {
    if (cnt > half_lines) {
        gamma = gamma * 2 + 1;
        epsilon = epsilon * 2;
    } else {
        gamma = gamma * 2;
        epsilon = epsilon * 2 + 1;
    }
}

Console.WriteLine ("gamma: {0}, epsilon: {1}, answer: {2}", gamma, epsilon, gamma*epsilon);