using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Models
{
    public class Board
    {
        public Board(int length)
        {
            Length = length;

            Squares = new BoardSquare[length * length, length* length];

            for (int x = 0; x < length * length; x++)
            {
                for (int y = 0; y < length * length; y++)
                {
                    Squares[x, y] = new BoardSquare() { CanEdit = true };
                }
            }
        }

        public BoardSquare[,] Squares
        {
            get;
            set;
        }

        public readonly int Length;

        public BoardSquare this[int x, int y]
        {
            get
            {
                return Squares[x, y];
            }
            set
            {
                Squares[x, y] = value;
            }
        }
    }
}
