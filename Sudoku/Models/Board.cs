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
        }

        public BoardSquare[,] BoardSquares
        {
            get;
            set;
        }


    }
}
