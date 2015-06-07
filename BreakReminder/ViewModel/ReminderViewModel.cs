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

            RecurrenceMin = 5;
        }

        #endregion

    }
}
