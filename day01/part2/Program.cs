int increaseCount =0;
int previous =int.MaxValue;
string? line;
List<int> measurements = new();

while ((line = Console.ReadLine()) != null) {
    measurements.Add(int.Parse(line));
}

for (int i =0; i < measurements.Count - 2; i++) {
    int current = measurements[i]+measurements[i+1]+measurements[i+2];
    if (current > previous) {
        increaseCount++;
    }
    previous = current;
}

Console.WriteLine("{0} increases", increaseCount);