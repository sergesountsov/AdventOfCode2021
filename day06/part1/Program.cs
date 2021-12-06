int[] input = {2,5,3,4,4,5,3,2,3,3,2,2,4,2,5,4,1,1,4,4,5,1,2,1,5,2,1,5,1,1,1,2,4,3,3,1,4,2,3,4,5,1,2,5,1,2,2,5,2,4,4,1,4,5,4,2,1,5,5,3,2,1,3,2,1,4,2,5,5,5,2,3,3,5,1,1,5,3,4,2,1,4,4,5,4,5,3,1,4,5,1,5,3,5,4,4,4,1,4,2,2,2,5,4,3,1,4,4,3,4,2,1,1,5,3,3,2,5,3,1,2,2,4,1,4,1,5,1,1,2,5,2,2,5,2,4,4,3,4,1,3,3,5,4,5,4,5,5,5,5,5,4,4,5,3,4,3,3,1,1,5,2,4,5,5,1,5,2,4,5,4,2,4,4,4,2,2,2,2,2,3,5,3,1,1,2,1,1,5,1,4,3,4,2,5,3,4,4,3,5,5,5,4,1,3,4,4,2,2,1,4,1,2,1,2,1,5,5,3,4,1,3,2,1,4,5,1,5,5,1,2,3,4,2,1,4,1,4,2,3,3,2,4,1,4,1,4,4,1,5,3,1,5,2,1,1,2,3,3,2,4,1,2,1,5,1,1,2,1,2,1,2,4,5,3,5,5,1,3,4,1,1,3,3,2,2,4,3,1,1,2,4,1,1,1,5,4,2,4,3};

long[] fishCount = new long[9];

foreach (var fish in input) {
    fishCount[fish] +=1;
}

PrintFish(fishCount);
for(int step = 1; step <= 80; step++) {
    Step(fishCount);
}

var totalFish = fishCount.Aggregate(0L,(count,next) => count + next);
Console.WriteLine ($"Part1: {totalFish}");

for (int step = 81; step <=256; step++) {
    Step(fishCount);
}

PrintFish(fishCount);
totalFish = fishCount.Aggregate(0L,(count,next) => count + next);
Console.WriteLine ($"Part2: {totalFish}");

void PrintFish(long[] fishCount) {
    for  (int i =0; i < fishCount.Length; i++) {
        Console.WriteLine($"{i}: {fishCount[i]}");
    }
}

void Step(long[] fishCount) {
    long fishAtZero = fishCount[0];

    for (int i = 1; i < fishCount.Length; i++) {
        fishCount[i-1]=fishCount[i];
    }
    fishCount[6] += fishAtZero;
    fishCount[8] = fishAtZero;
 }