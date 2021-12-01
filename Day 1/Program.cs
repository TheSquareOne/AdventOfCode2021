using System;
using System.Collections.Generic;

class Day_1
{
    static void Main(string[] args)
    {
        string[] rawData = System.IO.File.ReadAllLines(@".\inputData.txt");     // Get rawData from inputData.txt
        List<int> data = new List<int>();

        foreach (var item in rawData)
        {
            data.Add(int.Parse(item));      // Convert to int
        }

        // Console.WriteLine(data.Count);
        // Console.WriteLine(data.GetType());
        // Console.WriteLine(data[0].GetType());

        Console.WriteLine("\nPart A ~");
        Console.WriteLine($"Number of times a depth measurement increases: {partA(data)}\n");

        Console.WriteLine("\nPart B ~");
        Console.WriteLine($"Number of times the sum of measurements in sliding window increases: {partB(data)}\n");
    }

    static int partA (List<int> data)
    {
        int incrementCount = 0;

        // Count each increment
        for(int i = 1; i < data.Count; i++) if(data[i] > data[i-1]) incrementCount++;
        return incrementCount;
    }

        static int partB (List<int> data)
    {
        int incrementCount = 0;

        // Count each increment
        for(int i = 3; i < data.Count; i++) if((data[i-3] + data[i-2] + data[i-1]) < (data[i-2] + data[i-1] + data[i])) incrementCount++;
        return incrementCount;
    }
}