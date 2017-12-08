using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Models
{
    public class Board
    {
        public Board()
        {
            BoardSquares = new BoardSquare[9, 9];

            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    BoardSquares[x, y] = new BoardSquare() { CanEdit = true };
                }
            }
        }

        public BoardSquare[,] BoardSquares
        {
            get;
            set;
        }


    }
}
