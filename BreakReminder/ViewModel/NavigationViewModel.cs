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
        private readonly ICommand _showReminderCommand;

        #endregion

        #region Constructor

        public NavigationViewModel(Window mainWindow, ViewModelBase currentViewModel, UserControl currentControl)
        {
            _mainWindow = mainWindow;           
            _currentViewModel = currentViewModel;
            _currentControl = currentControl;
            _changeToCountDownCommand = new DelegateCommand(ExecuteChangeToCountDownCommand, CanExecuteCommand);
            _showReminderCommand = new DelegateCommand(ExecuteShowReminderCommand, CanExecuteCommand);
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

        public ICommand ShowReminderCommand
        {
            get
            {
                return _showReminderCommand;
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
            _currentViewModel = new CountDownViewModel(_currentViewModel.RecurrenceMin, this);
        }

        private void ExecuteShowReminderCommand(object obj)
        {
            _currentControl = new ReminderControl();
            _mainWindow.Content = _currentControl;
            _mainWindow.WindowState = WindowState.Maximized;
            _mainWindow.Activate();
        }
        #endregion
    }
}
