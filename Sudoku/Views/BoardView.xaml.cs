using Sudoku.Models;
using Sudoku.ViewModel;
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
    public partial class BoardView : Window
    {
        public BoardView()
        {
            InitializeComponent();
        }


        public BoardSquare FocusedSquare
        {
            get { return (BoardSquare)this.GetValue(FocusedSquareProperty); }
            set { this.SetValue(FocusedSquareProperty, value); }
        }

        public static readonly DependencyProperty FocusedSquareProperty = DependencyProperty.Register(
                "FocusedSquare", typeof(BoardSquare), typeof(BoardView), new PropertyMetadata(default(BoardSquare)));

        private void Button_GotFocus(object sender, RoutedEventArgs e)
        {
            FrameworkElement source = e?.Source as FrameworkElement;

            FocusedSquare = source?.DataContext as BoardSquare;
        }

        private void Button_LostFocus(object sender, RoutedEventArgs e)
        {
            FrameworkElement source = e?.Source as FrameworkElement;

            BoardSquare lostSquare = source?.DataContext as BoardSquare;

            if (lostSquare == FocusedSquare)
            {
                FocusedSquare = null;
            }
        }

        public void BindDataContext()
        {
            BoardViewModel vm = DataContext as BoardViewModel;

            if (vm != null)
            {
                Binding selectedSquareBinding = new Binding();

                selectedSquareBinding.Source = vm;
                selectedSquareBinding.Path = new PropertyPath("SelectedSquare");
                selectedSquareBinding.Mode = BindingMode.TwoWay;
                selectedSquareBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                BindingOperations.SetBinding(this, BoardView.FocusedSquareProperty, selectedSquareBinding);

            }


        }
    }
}
