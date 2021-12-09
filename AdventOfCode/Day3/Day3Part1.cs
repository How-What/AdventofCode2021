using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day3
{
    //Day 3 Part 1: https://adventofcode.com/2021/day/3
    internal static class Day3Part1
    {
        private static string inputfile = @".\Day3\input.txt";

        public static void GetAnswer()
        {
            string[] lines = File.ReadAllLines(inputfile);
            int[] one = new int[lines[0].Length];
            int[] zero = new int[one.Length];
            int count = 0;

            string gamma = "";
            string epsilon = "";
            foreach (string line in File.ReadLines(inputfile))
            {
                for(int i = 0; i < line.Length; i++)
                {
                    if (line[i] == '1')
                    {
                        one[i] ++;
                    }
                    else
                    {
                        zero[i] ++;
                    }
                }
            }
            for (int i = 0; i < one.Length; i++)
            {
                if (one[i] > zero[i])
                {
                    gamma += "1";
                    epsilon += "0";
                }
                else
                {
                    gamma += "0";
                    epsilon += "1";
                }
            }
            Console.WriteLine("Non Parallel: {0}", Convert.ToInt32(gamma,2) * Convert.ToInt32(epsilon, 2));
        }

        public static void GetAnswerParallel()
        {
            string[] lines = File.ReadAllLines(inputfile);
            int[] one = new int[lines[0].Length];
            int[] zero = new int[one.Length];

            int paracount = 0;

            string gamma = "";
            string epsilon = "";
            Parallel.ForEach(File.ReadLines(inputfile), x =>
            {
                Parallel.For(0, x.Length, i =>
                {
                    if (x[i] == '1')
                    {
                        one[i]++;
                    }
                    else
                    {
                        zero[i]++;
                    }
                });
                paracount++;
            });

            for (int i = 0; i < one.Length; i++)
            {
                if (one[i] > zero[i])
                {
                    gamma += "1";
                    epsilon += "0";
                }
                else
                {
                    gamma += "0";
                    epsilon += "1";
                }
            }

            Console.WriteLine("Parallel: {0} {1}", Convert.ToInt32(gamma, 2) * Convert.ToInt32(epsilon, 2), paracount);
        }
    }
}
