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
            Values = new int[9, 9];
            CanEdit = new bool[9, 9];
        }

        public int[,] Values
        {
            get;
            set;
        }


        public bool[,] CanEdit
        {
            get;
            set;
        }
    }
}
