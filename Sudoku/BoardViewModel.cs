using Sudoku.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.ViewModels
{
    class BoardViewModel : INotifyPropertyChanged 
    {
        Board _board;

        public BoardViewModel(Board board)
        {
            _board = board;

            Values = new List<List<int?>>(9);
            CanEdit = new List<List<bool>>(9);

            for (int x = 0; x < 9; x++)
            {
                Values.Add(new List<int?>(9));
                CanEdit.Add(new List<bool>(9));

                for (int y = 0; y < 9; y++)
                {
                    Values[x].Add(board.Values[x, y]);
                    CanEdit[x].Add(board.CanEdit[x, y]);
                }
            }
        }


        public List<List<int?>> Values;
        public List<List<bool>> CanEdit;

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
