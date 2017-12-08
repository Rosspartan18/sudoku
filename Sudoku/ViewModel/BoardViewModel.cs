using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Sudoku.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sudoku.ViewModel
{
    class BoardViewModel : ObservableObject
    {
        Board _board;

        public BoardViewModel(Board board)
        {
            _board = board;

            BoardSquares = new List<List<BoardSquare>>(9);

            for (int x = 0; x < 9; x++)
            {
                BoardSquares.Add(new List<BoardSquare>(9));

                for (int y = 0; y < 9; y++)
                {
                    BoardSquares[x].Add(board.BoardSquares[x, y]);
                }
            }
        }


        public List<List<BoardSquare>> BoardSquares { get; set; }

        private BoardSquare _selected;
        public BoardSquare Selected
        {
            get
            {
                return _selected;
            }
            set
            {
                if (_selected != value)
                {
                    _selected = value;
                    RaisePropertyChanged("Selected");
                }
            }
        }


        RelayCommand<Key> NumberKeyPressedCommand = new RelayCommand<Key>((key) =>
        {

        });

    }

}
