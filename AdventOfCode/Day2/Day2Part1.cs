
namespace AdventOfCode.Day2
{
    internal static class Day2Part1
    {
        private static string inputfile = @".\Day2\input.txt";

        private static Dictionary<char, int> MoveShip()
        {
            Dictionary<char, int> result = new Dictionary<char, int>()
            {
                {'x', 0 },
                {'y', 0 }
            };
            foreach (string line in File.ReadAllLines(inputfile))
            {
                string[] templine = line.Split(' ');
                string direction = templine[0];
                int steps = int.Parse(templine[1]);

                if (direction == Direction.Forward)
                {
                    result['x'] += steps;
                }
                else if (direction == Direction.Up)
                {
                    result['y'] -= steps;
                }
                else if (direction == Direction.Down)
                {
                    result['y'] += steps;
                }
            }

            //Attemped at a parallel for loop seems to skip a lot of the steps
            //Parallel.ForEach(File.ReadLines(inputfile), line =>
            //{
            //    string[] templine = line.Split(' ');
            //    string direction = templine[0];
            //    int steps = int.Parse(templine[1]);

            //    if (templine[0] == Direction.Forward)
            //    {
            //        result['x'] += int.Parse(templine[1]);
            //    }
            //    else if (templine[0] == Direction.Up)
            //    {
            //        result['y'] -= int.Parse(templine[1]);
            //    }
            //    else if (templine[0] == Direction.Down)
            //    {
            //        result['y'] += int.Parse(templine[1]);
            //    }

            //});

            return result;
        }

        public static void GetAnswer()
        {
            var answer = MoveShip();
            Console.WriteLine("Day2 Part 1: {0}", answer['x'] * answer['y']);
        }
    }

    
}
