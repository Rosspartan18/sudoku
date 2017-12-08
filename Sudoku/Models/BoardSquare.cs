using Sudoku.MVVM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Models
{
    public class BoardSquare : NotifyPropertyChanged
    {
        private int? _value;
        public int? Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (_value != value)
                {
                    _value = value;
                    RaisePropertyChanged("Value");
                }
            }
        }

        private bool _canEdit;
        public bool CanEdit
        {
            get
            {
                return _canEdit;
            }
            set
            {
                if (_canEdit != value)
                {
                    _canEdit = value;
                    RaisePropertyChanged("CanEdit");
                }
            }
        }
    }
}
