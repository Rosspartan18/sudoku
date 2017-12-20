using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Sudoku.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

            BoardSquares = new ObservableCollection<ObservableCollection<BoardSquare>>();

            for (int x = 0; x < 9; x++)
            {
                BoardSquares.Add(new ObservableCollection<BoardSquare>());

                for (int y = 0; y < 9; y++)
                {
                    BoardSquares[x].Add(board.BoardSquares[x, y]);
                }
            }

            NumberKeyPressedCommand = new RelayCommand<string>(this.NumberKeyPressedAction);
        }


        public ObservableCollection<ObservableCollection<BoardSquare>> BoardSquares { get; set; }

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
