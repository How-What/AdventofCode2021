using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day3
{
    //Day 2 Part 2: https://adventofcode.com/2021/day/3
    internal static class Day3part2
    {
        private static string inputfile = @".\Day3\input.txt";

        public static int Process()
        {
            string [] lines = File.ReadAllLines(inputfile);
            string[] most = lines;
            string[] least = lines;

            int index = 0;

            while (most.Length != 1 || least.Length != 1)
            {
                most = GetReamainingFromList(most, index, true);
                least = GetReamainingFromList(least,index, false);
                index++;
            }

            return Convert.ToInt32(most[0], 2) * Convert.ToInt32(least[0], 2);
        }

        private static string[] GetReamainingFromList(string[] list, int index, Boolean most)
        {
            int[] oz = ColumnCounter(list, index);
            int zero = oz[0];
            int one = oz[1];

            if (one > zero || one == zero)
            {
                if (most)
                {
                    return (list.Length != 1) ? ExtractFromList(list, '1', index) : list;
                }
                else
                {
                    return (list.Length != 1) ? ExtractFromList(list, '0', index) : list;
                }
                

            }
            else
            {
                if (most)
                {
                    return (list.Length != 1) ? ExtractFromList(list, '0', index) : list;
                }
                else
                {
                    return (list.Length != 1) ? ExtractFromList(list, '1', index) : list;
                }
                
            }
        }

        private static int [] ColumnCounter(string[] list, int index)
        {
            int[] oneszero = new int[2];
            foreach (string line in list)
            {
                if (line[index] == '1')
                {
                    oneszero[1]++;
                }
                else
                {
                    oneszero[0]++;
                }
            }

            return oneszero;
        }

        private static string[] ExtractFromList(string[] list, char val, int index)
        {
            List<string> result = new List<string>();
            foreach (string line in list)
            {
                if (line[index] == val)
                {
                    result.Add(line);
                }
            }
            return result.ToArray();
        }

        public static void GetAnswer()
        {
            Console.WriteLine($"Day 3 Part 2: {Process()}");
        }
    }
}
