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

            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    BoardSquare boardSquare = new BoardSquare();

                    boardSquare.Value = x + y;
                    boardSquare.CanEdit = (((x + y) % 2) == 0);

                    board.BoardSquares[x, y] = boardSquare;
                }
            }

            BoardViewModel viewModel = new BoardViewModel(board);

            MainWindow window = new Sudoku.MainWindow();

            window.DataContext = viewModel;

            window.Show();
        }
    }
}
