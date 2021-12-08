using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day1
{
    //Day 1 part 2: https://adventofcode.com/2021/day/1#part2
    internal static class Day1p2
    {
        private static string inputfile = @".\Day1\data.txt";
        private static int SonarSweep(int[] depth)
        {
            //takes the sum of the firt three for measurement the compares the second window
            int prevdepth = ThreeSum(depth[0], depth[1], depth[2]);
            int numberofScans = depth.Length;
            int countOfIncreases = 0;

            for (int i = 3; i < numberofScans; i++)
            {
                int currentSumedDepth = ThreeSum(depth[i], depth[i - 1], depth[i - 2]);
                if (currentSumedDepth > prevdepth)
                {
                    countOfIncreases++;
                }
                prevdepth = currentSumedDepth;
            }

            return countOfIncreases;
        }

        private static int ThreeSum(int a, int b, int c)
        {
            return a + b + c;  
        }

        //Hard code reads fron data.txt
        private static int[] ReadFromFile()
        {
            return Array.ConvertAll(System.IO.File.ReadAllLines(inputfile), int.Parse);
        }

        public static void GetDay1Answer()
        {
            Console.WriteLine("Day1 Part2: {0}", SonarSweep(ReadFromFile()));
        }
    }
}
