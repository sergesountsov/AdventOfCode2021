List<string> lines = new();
string? line;

while((line =Console.ReadLine())!= null ) {
    lines.Add(line);
}

List<string> mostCommon = new(lines);
for (int i = 0; i < lines[0].Length; i++) {
    Split(mostCommon, i, out var ones, out var zeroes);
    if (ones.Count >= zeroes.Count ){
        mostCommon = ones;
    } else {
        mostCommon=zeroes;
    }
    if (mostCommon.Count ==1) {
        break;
    }
}

List<string> leastCommon = new(lines);
for (int i = 0; i < lines[0].Length; i++) {
    Split(leastCommon, i, out var ones, out var zeroes);
    if (ones.Count >= zeroes.Count ){
        leastCommon = zeroes;
    } else {
        leastCommon=ones;
    }
    if (leastCommon.Count ==1) {
        break;
    }
}

Console.WriteLine("Most common Count: {0}, least common count {1}", mostCommon.Count, leastCommon.Count);
int oxygen = ConvertFromBinary(mostCommon[0]);
int co2 = ConvertFromBinary(leastCommon[0]);
Console.WriteLine("Oxygen: {0} ({1}), Co2: {2} ({3}), result: {4}", oxygen, mostCommon[0], co2, leastCommon[0], oxygen * co2);

void Split(List<string> lines, int position, out List<string> ones, out List<string> zeroes) {
    ones = new();
    zeroes = new();
    foreach (var line in lines ) {
        if (line[position] =='1') {
            ones.Add(line);
        } else {
            zeroes.Add(line);
        }
    }
}

int ConvertFromBinary (string s) {
    int result=0;
    foreach (char c in s) {
        result *= 2;
        if (c == '1') {
            result += 1;
        }
    }
    return result;
}