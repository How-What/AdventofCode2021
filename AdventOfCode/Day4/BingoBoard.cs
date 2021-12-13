using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day4
{
    internal class BingoBoard
    {
        static int idcounter = 0;
        public int[,] Board { get; set; }
        public bool[,] MarkedBoard { get; set; }
        public int Boardid { get; set; }


        public BingoBoard(int[,] boardnums)
        {
            Boardid = idcounter;
            Interlocked.Increment(ref idcounter);
            Board = boardnums;
            MarkedBoard = new bool[5,5]
                { { false,false,false,false,false},
                { false,false,false,false,false},
                { false,false,false,false,false},
                { false,false,false,false,false},
                { false,false,false,false,false},};
        }
        
        public void RegisterNumber(int n)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (Board[i,j] == n)
                    {
                        MarkedBoard[i,j] = true;
                    }
                }
            }
        }

        public bool IsBingo()
        {
            for (int i = 0; i < 5; i++)
            {
                int marked = 0;
                for (int j = 0; j < 5; j++)
                {
                    if (!MarkedBoard[i, j])
                    {
                        break;
                    }
                    marked++;
                }
                if(marked == 5)
                {
                    return true;
                }
            }

            for (int i = 0; i < 5; i++)
            {
                int marked = 0;
                for (int j = 0; j < 5; j++)
                {
                    if (!MarkedBoard[j,i])
                    {
                        break;
                    }
                    marked++;
                }
                if (marked == 5)
                {
                    return true;
                }
            }
            return false;
        }
        
        public int TotalUnMarked()
        {
            int total = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if(MarkedBoard[i, j] == false)
                    {
                        total += Board[i, j];
                    }
                }
            }
            return total;
        }
    }
}
