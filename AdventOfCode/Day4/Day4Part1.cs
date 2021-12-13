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
            var bingoBoard = GetIndividualBoard(board);
            
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

        private static List<Dictionary<int, bool>> GetBingoBoard(List<string> boards)
        {
            List<Dictionary<int, bool>> retres = new List<Dictionary<int, bool>>();
            Dictionary<int, bool> result = new Dictionary<int,bool>();
            foreach (string line in boards)
            {
                foreach (var i in Regex.Split(line, @"\s+"))
                {
                    try
                    {
                        result.Add(Int32.Parse(i), false);
                    }
                    catch
                    {
                        continue;
                    }
                    
                }
                retres.Add(result);
                result = new Dictionary<int,bool>();
            }

            return retres;
        }
        private static List<List<Dictionary<int, bool>>> GetIndividualBoard(List<Dictionary<int, bool>> board)
        {
            var result = new List<List<Dictionary<int,bool>>>();

            for(int i = 0; i < board.Count; i+=5)
            {
                result.Add(board.GetRange(i, 5));
            }

            return result;
        }
    }
}
