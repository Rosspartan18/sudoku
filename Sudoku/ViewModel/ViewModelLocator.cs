/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:Sudoku"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using Sudoku.Models;

namespace Sudoku.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            SimpleIoc.Default.Register<BoardViewModel>(CreateBoardViewModel);
        }

        public BoardViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<BoardViewModel>();
            }
        }
        
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }

        static BoardViewModel CreateBoardViewModel()
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

            return new BoardViewModel(board);
        }
    }
}