using System.Text.RegularExpressions;

namespace AdventOfCode.Day4
{
    internal static class Day4Part1
    {
        private static string inputfile = @".\Day4\input.txt";
        private static string[] bingoCalls = File.ReadLines(inputfile).First().Split(',');

        internal static void GetAnswer()
        {
            var boards = GetBingoBoards();
            var board = GetBingoBoard(boards);

        }

        private static List<string> GetBingoBoards()
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
