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
        public BoardSquare()
        {
            _value = null;
            _valid = true;
            _canEdit = true;
        }

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

        private bool _valid;
        public bool Valid
        {
            get
            {
                return _valid;
            }
            set
            {
                if (_valid != value)
                {
                    _valid = value;
                    RaisePropertyChanged("Valid");
                }
            }
        }


        public override string ToString()
        {
            return String.Format("Value: {0}; CanEdit: {1}; Valid: {2}", (!_value.HasValue) ? "NULL" : _value.ToString(), CanEdit, Valid);
        }
    }
}
