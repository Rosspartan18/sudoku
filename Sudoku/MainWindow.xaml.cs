using Sudoku.Models;
using Sudoku.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sudoku
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BoardViewModel viewModel;

        public MainWindow()
        {
            InitializeComponent();

            Board board = new Board();

            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    board.Values[x, y] = x+y;
                    board.CanEdit[x, y] = (((x+y) % 2) == 0);
                }
            }

            viewModel = new BoardViewModel(board);

            DataContext = viewModel;
        }
    }
}
