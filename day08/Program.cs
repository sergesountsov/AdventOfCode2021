
int FindResult (Func<string[], string[], int> decode) {
    string? line;
    int result =0;
    while ((line = Console.ReadLine())!=null) {
        var parts = line.Split(" | ");
        var outputs = parts[1].Split(' ');
        Console.WriteLine(line);
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

int Part2Decode (string[] patternStrings, string[] outputs) {
    Dictionary<int, HashSet<char>> numToPattern = new();
    Dictionary<char, char> decoder = new();
    List<HashSet<char>> unknownPatterns = new();
    foreach (var ps in patternStrings) {
        var p = new HashSet<char>(ps.ToCharArray());
        switch (p.Count) {
            case 2: numToPattern[1] = p; break;
            case 3: numToPattern[7] = p; break;
            case 4: numToPattern[4] = p; break;
            case 7: numToPattern[8] = p; break;
            default: unknownPatterns.Add(p); break;
        }
    }

//  Compare 1 (len 2) and 7 (len 3) - identify top segment (a)
    var temp = new HashSet<char>(numToPattern[7]);
    temp.ExceptWith(numToPattern[1]);
    decoder['a']=temp.First();

// Find 9: Compare 4 (len 4) and 0,6,9 (len 6) - find the one which has all segments from 4 -> 9. 
    numToPattern[9] = unknownPatterns.Where(p=>p.Count == 6 && numToPattern[4].IsProperSubsetOf(p)).First();
    unknownPatterns.Remove(numToPattern[9]);
// We know top segment (a) and segments for 4 -> get bottom segment (g)    
    temp  =  new HashSet<char>(numToPattern[9]);
    temp.Remove(decoder['a']);
    temp.ExceptWith(numToPattern[4]);
    decoder['g']=temp.First();
// Find 3: Compare 1 (len2) with all 2,3,5 (len 5)
    numToPattern[3] = unknownPatterns.Where(p=>p.Count == 5 && numToPattern[1].IsProperSubsetOf(p)).First();
    unknownPatterns.Remove(numToPattern[3]);
// if we remove 1 , (a) and (g) from 3 only (d) is left  
    temp = new HashSet<char>(numToPattern[3]);
    temp.Remove(decoder['a']);
    temp.Remove(decoder['g']);
    temp.ExceptWith(numToPattern[1]);
    decoder['d'] = temp.First();
// From 4 remove 1 and d -> get b
    temp = new HashSet<char>(numToPattern[4]);
    temp.ExceptWith(numToPattern[1]);
    temp.Remove(decoder['d']);
    decoder['b']  = temp.First();
// find 5 - len5 and has b 
    numToPattern[5] = unknownPatterns.Where(p=>p.Count ==5 && p.Contains(decoder['b'])).First();
    unknownPatterns.Remove(numToPattern[5]);
// from 5 remove a,b,d,g -> get f
    temp = new HashSet<char>(numToPattern[5]);
    temp.Remove(decoder['a']);
    temp.Remove(decoder['b']);
    temp.Remove(decoder['d']);
    temp.Remove(decoder['g']);
    decoder['f']=temp.First();
// from 1 remove f - find c
    decoder['c'] = numToPattern[1].First(c=> c!= decoder['f']);
// from 8 remove 9 - find e
    decoder['e'] = numToPattern[8].First(c=> !numToPattern[9].Contains(c));

    Dictionary<string,int> patternToNum = new();
    List<string> originalPatterns =  new() {"abcefg","cf","acdeg","acdfg","bcdf","abdfg","abdefg","acf","abcdefg","abcdfg"};
    for (int i=0; i < originalPatterns.Count; i++)  {
        System.Text.StringBuilder sb = new();
        foreach (char c in originalPatterns[i])  {
            sb.Append(decoder[c]);

        }
        patternToNum[sb.ToString()]=i;
        Console.WriteLine($"${i}={sb}");
    }

    return patternToNum[outputs[0]]*1000+ patternToNum[outputs[1]]*100+patternToNum[outputs[2]]*10+patternToNum[outputs[3]];
}
Console.WriteLine($"Part1 result: {FindResult(Part2Decode)}");