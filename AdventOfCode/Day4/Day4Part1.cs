using System.Text.RegularExpressions;

namespace AdventOfCode.Day4
{
    internal static class Day4Part1
    {
        private static string inputfile = @".\Day4\input.txt";
        private static string[] bingoCalls = File.ReadLines(inputfile).First().Split(',');


        public static void GetAnswer()
        {
            Console.WriteLine($"Day 4 Part 1: {GetScore()}");
        }
        private static int GetScore()
        {
            int answer;
            List<BingoBoard> boards = GetBingoBoard(ExtractBingoList());
            foreach (string i in bingoCalls)
            {
                int num = int.Parse(i);
                foreach(BingoBoard board in boards)
                {
                    board.RegisterNumber(num);
                    if (board.IsBingo())
                    {
                        return board.TotalUnMarked() * num;
                    }
                }
            }
            return 0;
        }

        private static List<string> ExtractBingoList()
        {
            bool firstpass = true;
            string pattern = @"([0-9])+";

            List<string> list = new List<string>();
            foreach (string line in File.ReadLines(inputfile))
            {
                Match match = Regex.Match(line, pattern);

                if (firstpass)
                {
                    firstpass = false;
                    continue;
                }
                if (match.Success)
                {
                    list.Add(line);
                }
            }

            return list;
        }

        private static List<BingoBoard> GetBingoBoard(List<string> boards)
        {
            List<BingoBoard> list = new List<BingoBoard>();
            
            int i = 0;
            int[,] board = new int[5, 5];
            foreach (string line in boards)
            {
                int j = 0;
                foreach (var num in Regex.Split(line, @"\s+"))
                {
                    try
                    {
                        board[i, j] = Int32.Parse(num);
                    }
                    catch
                    {
                        continue;
                    }
                    j++;
                }
                if (i == 4)
                {
                    list.Add(new BingoBoard(board));
                    board = new int[5, 5];
                    i=0;
                }
                else
                {
                    i++;
                }
            }
            return list;
        }
    }
}
