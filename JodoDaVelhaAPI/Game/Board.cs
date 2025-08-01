using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JodoDaVelhaAPI.Game
{
    public class Board
    {
        public char[] Cells {  get; set; }
        
        public Board()
        {
            Cells = Enumerable.Range(1, 9).Select(i => i.ToString()[0]).ToArray();
        }

        public void Display()
        {
            Console.WriteLine($"{Cells[0]} | {Cells[1]} | {Cells[2]}");
            Console.WriteLine("---+---+--");
            Console.WriteLine($"{Cells[3]} | {Cells[4]} | {Cells[5]}");
            Console.WriteLine("---+---+--");
            Console.WriteLine($"{Cells[6]} | {Cells[7]} | {Cells[8]}");

        }
        
        public bool MakeMove(int position, char mark)
        {
            if (position < 1 || position > 9 || Cells[position - 1] == 'X' || Cells[position - 1] == 'O')
                return false;

            Cells[position - 1] = mark;
            return true;
        }

        public int CheckWinner()
        {
            int[,] winningCombos =
            {
        { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 },
        { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 },
        { 0, 4, 8 }, { 2, 4, 6 }
    };

            for (int i = 0; i < winningCombos.GetLength(0); i++)
            {
                int a = winningCombos[i, 0];
                int b = winningCombos[i, 1];
                int c = winningCombos[i, 2];

                if (Cells[a] == Cells[b] && Cells[b] == Cells[c])
                {
                    return 1; 
                }
            }

            if (Cells.All(c => c == 'X' || c == 'O'))
                return 0; 
            return -1; 
        }

    }
}
