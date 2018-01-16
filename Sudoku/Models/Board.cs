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
                    Squares[x, y] = new BoardSquare() { CanEdit = true, Valid=false};
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

        private List<BoardSquare> GetRow(int y)
        {
            List<BoardSquare> list = new List<BoardSquare>();

            for (int i = 0; i<Length*Length; i++)
            {
                list.Add(Squares[y, i]);
            }

            return list;
        }

        private List<BoardSquare> GetColumn(int x)
        {
            List<BoardSquare> list = new List<BoardSquare>();

            for (int i = 0; i < Length * Length; i++)
            {
                list.Add(Squares[i, x]);
            }

            return list;
        }

        private List<BoardSquare> GetBlock(int block_X, int block_Y)
        {
            List<BoardSquare> list = new List<BoardSquare>();

            for (int x = 0; x < Length; x++)
            {
                for (int y = 0; y < Length; y++)
                {
                    list.Add(Squares[block_X * Length + x, block_Y * Length + y]);
                }
            }

            return list;
        }

        public void Validate()
        {
            // Mark everything that does not have a value as invalid, and everything that does as valid.
            for (int x = 0; x < Length * Length; x++)
            {
                for (int y = 0; y < Length * Length; y++)
                {
                    Squares[x, y].Valid = (Squares[x, y].Value.HasValue);
                }
            }


            // Mark everything that is a duplicate as invalid.
            // Row and columns
            for (int i = 0; i < Length * Length; i++)
            {
                MarkDuplicateSquaresAsInvalid(GetRow(i), Length * Length);
                MarkDuplicateSquaresAsInvalid(GetColumn(i), Length * Length);
            }

            // Blocks
            for (int x = 0; x < Length; x++)
            {
                for (int y = 0; y < Length; y++)
                {
                    MarkDuplicateSquaresAsInvalid(GetBlock(x, y), Length * Length);
                }
            }
        }

        public static void MarkDuplicateSquaresAsInvalid( List<BoardSquare> squares, int MaxValue)
        {
            if (squares == null)
            {
                throw new NullReferenceException("squares parameter can not be null.");
            }

            if (squares.Count > 1)
            {
                var mapValueToListOfBoardSquares = Enumerable.Range(0, MaxValue + 1).Select((x) => new List<BoardSquare>()).ToArray();

                foreach (var square in squares)
                {
                    if (square.Value.HasValue)
                    {
                        List<BoardSquare> list = mapValueToListOfBoardSquares[square.Value.Value];

                        list.Add(square);
                    }
                }

                var SquaresWithCountsGreaterThan2AndCanEdit = mapValueToListOfBoardSquares.Where(x => x.Count > 1).SelectMany(x => x).Where(x => x.CanEdit).ToList();

                foreach (var square in SquaresWithCountsGreaterThan2AndCanEdit)
                {
                    square.Valid = false;
                }
            }
        }

    }
}
