using BreakReminder.Control;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BreakReminder.ViewModel
{
    public class NavigationViewModel
    {

        #region Private Declarations 

        private Window _mainWindow;
        private ViewModelBase _currentViewModel;
        private UserControl _currentControl;
        private readonly ICommand _changeToCountDownCommand;

        #endregion

        #region Constructor

        public NavigationViewModel(Window mainWindow, ViewModelBase currentViewModel, UserControl currentControl)
        {
            _mainWindow = mainWindow;           
            _currentViewModel = currentViewModel;
            _currentControl = currentControl;
            _changeToCountDownCommand = new DelegateCommand(ExecuteChangeToCountDownCommand, CanExecuteCommand);
        }

        #endregion

        #region Public Properties

        public ViewModelBase CurrentViewModel
        {
            get
            {
                return _currentViewModel;
            }
        }

        #endregion

        #region Public Commands

        public ICommand ChangeToCountDownCommand
        {
            get
            {
                return _changeToCountDownCommand;
            }
        }

        #endregion

        #region Private Methods

        private bool CanExecuteCommand(object obj)
        {
            return true;
        }

        private void ExecuteChangeToCountDownCommand(object obj)
        {
            _mainWindow.Content = new CountDownControl();
        }

        #endregion
    }
}
