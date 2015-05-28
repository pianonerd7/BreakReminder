using BreakReminder.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakReminder.ViewModel
{
    public class CountDownViewModel : ViewModelBase
    {

        private ReminderModel _countDownInfo;

        public CountDownViewModel(ReminderModel countDownInfo)
        {
            _countDownInfo = countDownInfo;
        }

        public ReminderModel CountDownInfo
        {
            get
            {
                return _countDownInfo;
            }
        }

    }
}
