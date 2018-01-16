using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Models
{
    public class BoardSquare : ObservableObject
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
                    Trace.WriteLine(String.Format("BoardSquare.Value changed from {0} to {1}", (!_value.HasValue) ? "NULL" : _value.ToString(), (!value.HasValue) ? "NULL" : value.ToString()));
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

        public override string ToString()
        {
            return String.Format("Value: {0}; CanEdit: {1};", (!_value.HasValue) ? "NULL" : _value.ToString(), CanEdit);
        }
    }
}
