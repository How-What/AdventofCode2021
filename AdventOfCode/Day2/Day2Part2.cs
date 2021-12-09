
namespace AdventOfCode.Day2
{
    //Day2 Part2: https://adventofcode.com/2021/day/2#part2
    internal class Day2Part2
    {
        private static string inputfile = @".\Day2\input.txt";

        private static Dictionary<char, int> MoveShip()
        {
            Dictionary<char, int> result = new Dictionary<char, int>()
            {
                {'x', 0 },  //horizonta;
                {'y', 0 },  //vertical
                {'a', 0 }, // a for aim
            };
            foreach (string line in File.ReadAllLines(inputfile))
            {
                string[] templine = line.Split(' ');
                //string direction = templine[0];
                //int steps = int.Parse(templine[1]);

                if (templine[0] == Direction.Forward)
                {
                    result['x'] += int.Parse(templine[1]); ;
                    result['y'] += result['a'] * int.Parse(templine[1]);
                }
                else if (templine[0] == Direction.Up)
                {
                    result['a'] -= int.Parse(templine[1]); ;
                }
                else if (templine[0] == Direction.Down)
                {
                    result['a'] += int.Parse(templine[1]); ;
                }
            }

            return result;
        }

        public static void GetAnswer()
        {
            var answer = MoveShip();
            Console.WriteLine("Day2 Part 2: {0}", answer['x'] * answer['y']);
        }
    }
}
