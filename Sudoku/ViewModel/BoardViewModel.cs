using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Sudoku.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
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

            Squares = new ObservableCollection<ObservableCollection<ObservableCollection<ObservableCollection<BoardSquare>>>>();

            for (int block_X = 0; block_X < board.Length; block_X++)
            {
                Squares.Add(new ObservableCollection<ObservableCollection<ObservableCollection<BoardSquare>>>());

                for (int block_Y = 0; block_Y < board.Length; block_Y++)
                {
                    Squares[block_X].Add(new ObservableCollection<ObservableCollection<BoardSquare>>());

                    for (int x=0; x < board.Length; x++)
                    {
                        Squares[block_X][block_Y].Add(new ObservableCollection<BoardSquare>());

                        for (int y=0; y < board.Length;y++)
                        {
                            Squares[block_X][block_Y][x].Add(board[block_X*board.Length + x, block_Y* board.Length + y]);
                        }
                    }
                }
            }

            NumberKeyPressedCommand = new RelayCommand<string>(this.NumberKeyPressedAction);
        }


        public ObservableCollection<ObservableCollection<ObservableCollection<ObservableCollection<BoardSquare>>>> Squares { get; set; }

        private BoardSquare _selectedSquare;
        public BoardSquare SelectedSquare
        {
            get
            {
                return _selectedSquare;
            }
            set
            {
                if (_selectedSquare != value)
                {
                    _selectedSquare = value;
                    RaisePropertyChanged("SelectedSquare");
                }
            }
        }


        public RelayCommand<String> NumberKeyPressedCommand
        {
            get;
            set;
        }

        void NumberKeyPressedAction(String key)
        {
            if ((key != null) && (SelectedSquare != null) && (SelectedSquare.CanEdit))
            {
                try
                {
                    int number = int.Parse(key);

                    if (number >=0 && number <= 10 )
                    {
                        Trace.WriteLine(String.Format("Change Selected Square Value from {0} to {1}", (!SelectedSquare.Value.HasValue) ? "NULL" : SelectedSquare.Value.ToString(), number));
                        SelectedSquare.Value = number;
                    }
                }
                catch (FormatException)
                {
                }
                catch (OverflowException)
                {
                }
            }
        }
    }
}
