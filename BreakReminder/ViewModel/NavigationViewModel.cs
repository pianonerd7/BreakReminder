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
        private ObservableCollection<ViewModelBase> _viewModelCollection;
        private ObservableCollection<UserControl> _userControlCollection;
        private ViewModelBase _currentViewModel;
        private UserControl _currentControl;
        private readonly ICommand _changeControlCommand;

        #endregion

        #region Constructor

        public NavigationViewModel(Window mainWindow, ViewModelBase currentViewModel, UserControl currentControl)
        {
            _mainWindow = mainWindow;

            _viewModelCollection = new ObservableCollection<ViewModelBase>() 
            {
                currentViewModel
            };

            _userControlCollection = new ObservableCollection<UserControl>() 
            {
                currentControl
            };
                    
            _currentViewModel = currentViewModel;
            _currentControl = currentControl;
            _changeControlCommand = new DelegateCommand(ExecuteChangeControlCommand, CanExecuteChangeControlCommand);
        }

        #endregion

        #region Public Commands

        public ICommand ChangeControlCommand
        {
            get
            {
                return _changeControlCommand;
            }
        }

        #endregion

        #region Private Methods

        private bool CanExecuteChangeControlCommand(object obj)
        {
            return true;
        }

        private void ExecuteChangeControlCommand(object obj)
        {
            //string newViewName = obj as string;

            //if (!_userControlCollection.Contains(newView))
            //{
            //    _userControlCollection.Add(newView);
            //}

            //_currentControl = newView;

            _mainWindow.Content = new CountDownControl();
        }

        #endregion
    }
}
