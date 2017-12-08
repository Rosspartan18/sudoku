using Sudoku.Models;
using Sudoku.ViewModels;
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
            Board board = new Board();

            board.BoardSquares[8, 0] = new BoardSquare() { Value = 9, CanEdit = false };
            board.BoardSquares[7, 1] = new BoardSquare() { Value = 1, CanEdit = false };
            board.BoardSquares[6, 2] = new BoardSquare() { Value = 8, CanEdit = false };

            board.BoardSquares[8, 4] = new BoardSquare() { Value = 2, CanEdit = false };
            board.BoardSquares[8, 5] = new BoardSquare() { Value = 6, CanEdit = false };
            board.BoardSquares[7, 4] = new BoardSquare() { Value = 5, CanEdit = false };
            board.BoardSquares[7, 5] = new BoardSquare() { Value = 3, CanEdit = false };
            board.BoardSquares[6, 4] = new BoardSquare() { Value = 4, CanEdit = false };
            board.BoardSquares[6, 5] = new BoardSquare() { Value = 1, CanEdit = false };

            board.BoardSquares[7, 6] = new BoardSquare() { Value = 7, CanEdit = false };
            board.BoardSquares[7, 8] = new BoardSquare() { Value = 2, CanEdit = false };
            board.BoardSquares[6, 8] = new BoardSquare() { Value = 5, CanEdit = false };

            board.BoardSquares[4, 0] = new BoardSquare() { Value = 5, CanEdit = false };
            board.BoardSquares[5, 1] = new BoardSquare() { Value = 6, CanEdit = false };
            board.BoardSquares[4, 2] = new BoardSquare() { Value = 1, CanEdit = false };
            board.BoardSquares[3, 2] = new BoardSquare() { Value = 7, CanEdit = false };

            board.BoardSquares[5, 3] = new BoardSquare() { Value = 3, CanEdit = false };
            board.BoardSquares[4, 3] = new BoardSquare() { Value = 6, CanEdit = false };
            board.BoardSquares[4, 5] = new BoardSquare() { Value = 4, CanEdit = false };
            board.BoardSquares[3, 5] = new BoardSquare() { Value = 8, CanEdit = false };

            board.BoardSquares[5, 6] = new BoardSquare() { Value = 4, CanEdit = false };
            board.BoardSquares[4, 6] = new BoardSquare() { Value = 8, CanEdit = false };
            board.BoardSquares[4, 8] = new BoardSquare() { Value = 7, CanEdit = false };
            board.BoardSquares[3, 7] = new BoardSquare() { Value = 3, CanEdit = false };

            board.BoardSquares[2, 0] = new BoardSquare() { Value = 1, CanEdit = false };
            board.BoardSquares[1, 0] = new BoardSquare() { Value = 7, CanEdit = false };
            board.BoardSquares[1, 2] = new BoardSquare() { Value = 6, CanEdit = false };

            board.BoardSquares[2, 3] = new BoardSquare() { Value = 5, CanEdit = false };
            board.BoardSquares[2, 4] = new BoardSquare() { Value = 6, CanEdit = false };
            board.BoardSquares[1, 3] = new BoardSquare() { Value = 1, CanEdit = false };
            board.BoardSquares[1, 4] = new BoardSquare() { Value = 8, CanEdit = false };
            board.BoardSquares[0, 3] = new BoardSquare() { Value = 4, CanEdit = false };
            board.BoardSquares[0, 4] = new BoardSquare() { Value = 3, CanEdit = false };

            board.BoardSquares[2, 6] = new BoardSquare() { Value = 2, CanEdit = false };
            board.BoardSquares[1, 7] = new BoardSquare() { Value = 9, CanEdit = false };
            board.BoardSquares[0, 8] = new BoardSquare() { Value = 1, CanEdit = false };

            BoardViewModel viewModel = new BoardViewModel(board);

            BoardView view = new Sudoku.BoardView();

            view.DataContext = viewModel;

            view.Show();
        }
    }
}
