using Sudoku.Models;
using Sudoku.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Sudoku
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Board board = new Board(3);

            board[8, 0] = new BoardSquare() { Value = 9, CanEdit = false };
            board[7, 1] = new BoardSquare() { Value = 1, CanEdit = false };
            board[6, 2] = new BoardSquare() { Value = 8, CanEdit = false };

            board[8, 4] = new BoardSquare() { Value = 2, CanEdit = false };
            board[8, 5] = new BoardSquare() { Value = 6, CanEdit = false };
            board[7, 4] = new BoardSquare() { Value = 5, CanEdit = false };
            board[7, 5] = new BoardSquare() { Value = 3, CanEdit = false };
            board[6, 4] = new BoardSquare() { Value = 4, CanEdit = false };
            board[6, 5] = new BoardSquare() { Value = 1, CanEdit = false };

            board[7, 6] = new BoardSquare() { Value = 7, CanEdit = false };
            board[7, 8] = new BoardSquare() { Value = 2, CanEdit = false };
            board[6, 8] = new BoardSquare() { Value = 5, CanEdit = false };

            board[4, 0] = new BoardSquare() { Value = 5, CanEdit = false };
            board[5, 1] = new BoardSquare() { Value = 6, CanEdit = false };
            board[4, 2] = new BoardSquare() { Value = 1, CanEdit = false };
            board[3, 2] = new BoardSquare() { Value = 7, CanEdit = false };

            board[5, 3] = new BoardSquare() { Value = 3, CanEdit = false };
            board[4, 3] = new BoardSquare() { Value = 6, CanEdit = false };
            board[4, 5] = new BoardSquare() { Value = 4, CanEdit = false };
            board[3, 5] = new BoardSquare() { Value = 8, CanEdit = false };

            board[5, 6] = new BoardSquare() { Value = 4, CanEdit = false };
            board[4, 6] = new BoardSquare() { Value = 8, CanEdit = false };
            board[4, 8] = new BoardSquare() { Value = 7, CanEdit = false };
            board[3, 7] = new BoardSquare() { Value = 3, CanEdit = false };

            board[2, 0] = new BoardSquare() { Value = 1, CanEdit = false };
            board[1, 0] = new BoardSquare() { Value = 7, CanEdit = false };
            board[1, 2] = new BoardSquare() { Value = 6, CanEdit = false };

            board[2, 3] = new BoardSquare() { Value = 5, CanEdit = false };
            board[2, 4] = new BoardSquare() { Value = 6, CanEdit = false };
            board[1, 3] = new BoardSquare() { Value = 1, CanEdit = false };
            board[1, 4] = new BoardSquare() { Value = 8, CanEdit = false };
            board[0, 3] = new BoardSquare() { Value = 4, CanEdit = false };
            board[0, 4] = new BoardSquare() { Value = 3, CanEdit = false };

            board[2, 6] = new BoardSquare() { Value = 2, CanEdit = false };
            board[1, 7] = new BoardSquare() { Value = 9, CanEdit = false };
            board[0, 8] = new BoardSquare() { Value = 1, CanEdit = false };

            BoardViewModel viewModel = new BoardViewModel(board);

            BoardView view = new Sudoku.BoardView();

            view.DataContext = viewModel;

            view.BindDataContext();

            view.Show();
        }
    }
}
