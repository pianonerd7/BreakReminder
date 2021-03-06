﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace BreakReminder.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged
    {

        #region Private Properties

        protected DateTime _startTime;
        protected double _recurrenceMin;

        #endregion

        #region Public Properties

        public DateTime StartTime
        {
            get
            {
                return _startTime;
            }
            set
            {
                _startTime = value;
                OnPropertyChanged("StartTime");
            }
        }

        public double RecurrenceMin
        {
            get
            {
                return _recurrenceMin;
            }
            set
            {
                _recurrenceMin = value;
                OnPropertyChanged("RecurrenceMin");
            }
        }

        #endregion

        #region INotifyProperty

        public event PropertyChangedEventHandler PropertyChanged;

        internal void OnPropertyChanged(string propertyName)
        {

            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
