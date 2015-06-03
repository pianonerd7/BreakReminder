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

        #region Private declarations

        private DateTime _startTime;
        private long _recurrenceMin;
        private readonly ICommand _startCommand;
        private Page page;

        #endregion

        #region Constructor 

        public ReminderViewModel (Page page)
        {
            _startTime = DateTime.Now;
            _recurrenceMin = 60;
            _startCommand = new DelegateCommand(ExecuteStartCommand, CanExecuteStartCommand);
            this.page = page;
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

        #region Commands

        public ICommand StartCommand
        {
            get
            {
                return _startCommand;
            }
        }

        #endregion

        #region Private Methods

        private bool CanExecuteStartCommand(object obj)
        {
            return true;
        }

        private void ExecuteStartCommand(object obj)
        {
            //_startTime.AddMinutes(_recurrenceMin);

            page.NavigationService.Navigate(new Uri("/Control/CountDownControl.xaml", UriKind.Relative));
        }

        #endregion

    }
}
