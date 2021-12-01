int increaseCount =0;
int previous =int.MaxValue;
string? line;

while ((line = Console.ReadLine()) != null) {
    var current = int.Parse(line);
    if (current > previous ) {
        increaseCount++;
    }
    previous = current;
}

Console.WriteLine("{0} increases", increaseCount);