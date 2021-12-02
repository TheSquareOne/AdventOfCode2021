using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Tuple<string, int>> instructions = new List<Tuple<string, int>>();
        
        foreach (var item in System.IO.File.ReadAllLines(@".\inputData.txt"))
        {
            string direction = item.Split()[0];
            int value = int.Parse(item.Split()[1]);
            instructions.Add(Tuple.Create<string, int>(direction, value));
        }

        Console.WriteLine($"\nPart One ~");
        Console.WriteLine($"Multiplied \t {PartOne(instructions)}\n");

        Console.WriteLine($"\nPart Two ~");
        Console.WriteLine($"Multiplied \t {PartTwo(instructions)}\n");
    }

    static int PartOne(List<Tuple<string, int>> data)
    {
        int x = 0;
        int y = 0;

        foreach (var item in data)
        {
            if(item.Item1 == "forward") x += item.Item2;
            else if(item.Item1 == "up") y -= item.Item2;
            else if(item.Item1 == "down") y += item.Item2;
        }

        Console.WriteLine($"Horizontal \t {x}\nDepths \t\t {y}");

        return x * y;
    }

    static int PartTwo(List<Tuple<string, int>> data)
    {
        int x = 0;
        int y = 0;
        int aim = 0;

        foreach (var item in data)
        {
            if(item.Item1 == "forward")
            {
                x += item.Item2;
                y += item.Item2 * aim;
            }
            else if(item.Item1 == "up") aim -= item.Item2;
            else if(item.Item1 == "down") aim += item.Item2;
        }

        Console.WriteLine($"Horizontal \t {x}\nDepths \t\t {y}\nAim \t\t {aim}");

        return x * y;
    }
}
