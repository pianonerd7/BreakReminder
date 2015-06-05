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

        private long _displayTime;
        private DispatcherTimer timer;

        #endregion

        #region Constructor

        public CountDownViewModel(long numMin)
        {
            timer = new DispatcherTimer();
            _displayTime = numMin * 60;
            Countdown();
        }

        #endregion

        #region Public Properties

        public long DisplayTime
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
            
            timer.Interval = new TimeSpan(0, 0, 1);

            timer.Tick += Ticker;
            //timer.Tick += (_, a) =>
            //    {
            //        if (numSeconds-- == 0)
            //        {
            //            timer.Stop();
            //        }
            //        else
            //        {
            //            curTime(numSeconds);
            //        }
            //    };
            //curTime(numSeconds);

            timer.Start();
        }
 
        private void Ticker(object sender, EventArgs e)
        {
            if (DisplayTime == 0)
            {
                timer.Stop();
                return;
            }

            DisplayTime--;

        }
        #endregion

    }
}
