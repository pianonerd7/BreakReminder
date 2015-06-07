using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace BreakReminder.ViewModel
{
    public class CountDownViewModel : ViewModelBase
    {

        #region Private Declaration

        private long _timerCounter;
        private string _displayTime;
        private DispatcherTimer _timer;
        private DateTime _time;
        private NavigationViewModel _navVM;

        #endregion

        #region Constructor

        public CountDownViewModel(long numMin, NavigationViewModel navVM)
        {
            _timer = new DispatcherTimer();
            _timerCounter = numMin;// *60;
            _time = new DateTime(2015, 1, 1, 0, 0, 0);
            _time = _time.AddSeconds(_timerCounter);
            _navVM = navVM;
            Countdown();
        }

        #endregion

        #region Public Properties

        public string DisplayTime
        {
            get
            {
                return _displayTime;
            }
            set
            {
                _displayTime = value;
                OnPropertyChanged("DisplayTime");
            }
        }
        #endregion

        #region Private Methods

        private void Countdown()
        {
            
            _timer.Interval = new TimeSpan(0, 0, 1);

            _timer.Tick += Ticker;

            _timer.Start();
        }
 
        private void Ticker(object sender, EventArgs e)
        {
            if (_timerCounter == 0)
            {
                _timer.Stop();
                _navVM.ShowReminderCommand.Execute(new object());
               
                return;
            }

            _timerCounter--;
            _time = _time.AddSeconds(-1);
            DisplayTime = String.Format("{0}:{1}:{2}", _time.Hour, _time.Minute, _time.Second);

        }
        #endregion

    }
}
