using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<string> data = new List<string>();
        
        foreach (var line in System.IO.File.ReadAllLines(@".\inputData.txt"))
        {
            data.Add(line);
        }
        
        Console.WriteLine("\nPart 1 ~\n");
        Console.WriteLine($"Power consumption: {PartOne(data)}\n");

        Console.WriteLine("\nPart 2 ~\n");
        Console.WriteLine($"Life support rating:\t {PartTwo(data)}\n");
    }

    static uint PartOne(List<string> data)
    {
        string gammaRate = "";
        string epsilonRate = "";

        for(int i = 0; i < data[0].Length; i++)
        {
            int countOnes = 0;

            foreach (var line in data)
            {
                if(line[i] == '1') countOnes++;     // Count amount of 1's
            }

            // Create binary string
            if(countOnes > (data.Count / 2))       // If over half is 1's add '1' to Gamma and '0' to Epsilon
            {
                gammaRate += '1';
                epsilonRate += '0';
            }
            else                                    // ^Reverse
            {
                gammaRate += '0';
                epsilonRate += '1';
            }
        }

        Console.WriteLine($"Gamma rate:\t {gammaRate} -> {Convert.ToUInt32(gammaRate, 2)}");
        Console.WriteLine($"Epsilon rate:\t {epsilonRate} -> {Convert.ToUInt32(epsilonRate, 2)}");

        return Convert.ToUInt32(gammaRate, 2) * Convert.ToUInt32(epsilonRate, 2);         // Convert binary string to integer and return multiplication

    }

    static uint PartTwo(List<string> data)
    {
        // Create temporary list's to keep track of Most and Least matching lines
        List<string> tempListMost = data;
        List<string> tempListLeast = data;

        string oxygen = "";             // Oxygen generator rating
        string scrubber = "";           // CO2 scrubber rating

        for(int i = 0; i < data[0].Length; i++)     // Loop through every bit
        {
            int countOnes = 0;      // Keep count of every '1'

            // Find here what is the most common bits for Oxygen generator rating
            if(tempListMost.Count > 1)      // If there is only 1 or less no reason to go through list
            {
                foreach (var line in tempListMost) if(line[i] == '1') countOnes++;      // Count amount of 1's on tempListMost

                // Create binary string
                if(countOnes >= (tempListMost.Count - countOnes))       // If more 1's add '1' to binary string else '0'
                {
                    oxygen += '1';
                }
                else oxygen += '0';

                tempListMost = tempListMost.FindAll(x => Regex.IsMatch(x, $"^{oxygen}"));       // Find all that match binary string and replace list
            }

            // Find here what is the least common bits for CO2 scrubber rating
            if(tempListLeast.Count > 1)     // If there is only 1 or less no reason to go through list
            {
                countOnes = 0;          // Reset count
                foreach (var line in tempListLeast) if(line[i] == '1') countOnes++;     // Count amount of 1's on tempListLeast

                // Create binary string
                if(countOnes >= (tempListLeast.Count - countOnes))      // If more 1's add '0' to binary string else '1'
                {
                    scrubber += '0';
                }
                else scrubber += '1';

                tempListLeast = tempListLeast.FindAll(x => Regex.IsMatch(x, $"^{scrubber}"));       // Find all that match binary string and replace list
            }
        }

        Console.WriteLine($"Oxygen generator rating: {tempListMost[0]} -> {Convert.ToUInt32(tempListMost[0], 2)}");
        Console.WriteLine($"CO2 scrubber rating:\t {tempListLeast[0]} -> {Convert.ToUInt32(tempListLeast[0], 2)}");

        return Convert.ToUInt32(tempListMost[0], 2) * Convert.ToUInt32(tempListLeast[0], 2);        // Convert binary string to integer and return multiplication
    }
}