using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day1
{
    //Day 1 Sonar sweep: https://adventofcode.com/2021/day/1
    internal static class Day1
    {
        private static string inputfile = @".\Day1\data.txt";
        private static int SonarSweep(int[] depth)
        {
            int prevdepth = depth[0];
            int numberofScans = depth.Length;
            int countOfIncreases = 0;   

            for(int i  = 1; i < numberofScans; i++)
            {
                if (depth[i] > prevdepth)
                {
                    countOfIncreases++;  
                }
                prevdepth = depth[i];
            }

            return countOfIncreases;
        }

        //Hard code reads fron data.txt
        private static int[] ReadFromFile()
        {
            return Array.ConvertAll(System.IO.File.ReadAllLines(inputfile), int.Parse);
        }

        public static void GetDay1Answer()
        {
            Console.WriteLine("Day1 Part 1: {0}", SonarSweep(ReadFromFile()));
        }
    }
}
