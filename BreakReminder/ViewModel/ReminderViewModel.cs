using BreakReminder.Control;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace BreakReminder.ViewModel
{
    public class ReminderViewModel : ViewModelBase
    {

        #region Constructor 

        public ReminderViewModel()
        {
            _startTime = DateTime.Now;
            _recurrenceMin = 60;
        }

        #endregion

        #region Public properties

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

        public long RecurrenceMin
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

    }
}
