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
                    board.Values[x, y] = x + y;
                    board.CanEdit[x, y] = (((x + y) % 2) == 0);
                }
            }

            BoardViewModel viewModel = new BoardViewModel(board);

            MainWindow window = new Sudoku.MainWindow();

            window.DataContext = viewModel;

            window.Show();
        }
    }
}
