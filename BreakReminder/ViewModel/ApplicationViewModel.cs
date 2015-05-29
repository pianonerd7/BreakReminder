using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace BreakReminder.ViewModel
{
    public class ApplicationViewModel
    {
        private ICommand _changePageCommand;
        private ViewModelBase _currentPageViewModel;
        private UserControl _currentControl;
        private ObservableCollection<ViewModelBase> _pageViewModels;
        private ObservableCollection<UserControl> _pageControls;

        #region Constructor

        public ApplicationViewModel(ObservableCollection<ViewModelBase> listOfVM, ObservableCollection<UserControl> listOfControl)
        {
            _pageViewModels = listOfVM;
            _pageControls = listOfControl;
            _currentPageViewModel = listOfVM[0];
            _currentControl = listOfControl[0];
            //_changePageCommand = new DelegateCommand(ExecuteChangePageCommand, CanExecuteChangePageCommand);
            _changePageCommand =  new DelegateCommand(p => ChangeViewModel((ViewModelBase)p),
                        p => p is ViewModelBase);
        }

        #endregion

        #region Properties

        public ObservableCollection<ViewModelBase> PageViewModels
        {
            get
            {
                return _pageViewModels;
            }
        }

        public ViewModelBase CurrentPageViewModel
        {
            get
            {
                return _currentPageViewModel;
            }
        }

        public UserControl CurrentControl
        {
            get
            {
                return _currentControl;
            }
        }

        #endregion


        #region Commands

        public ICommand ChangePageCommand
        {
            get
            {
                return _changePageCommand;
            }
        }

        #endregion

        #region Private Methods

        private bool CanExecuteChangePageCommand(object obj)
        {
            return true;
        }

        private void ExecuteChangePageCommand(object obj)
        {
            ChangeViewModel(obj as ViewModelBase);
        }

        private void ChangeViewModel(ViewModelBase vMBase)
        {
            //if (!_pageViewModels.Contains(vMBase))
            //{
            //    _pageViewModels.Add(vMBase);
            //}

            //_currentPageViewModel = vMBase;

            if (!PageViewModels.Contains(vMBase))
                PageViewModels.Add(vMBase);

            _currentPageViewModel = PageViewModels
                .FirstOrDefault(vm => vm == vMBase);
        }

        #endregion

    }
}
