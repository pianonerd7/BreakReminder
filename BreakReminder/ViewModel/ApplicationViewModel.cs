using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BreakReminder.ViewModel
{
    public class ApplicationViewModel
    {
        private ICommand _changePageCommand;
        private ViewModelBase _currentPageViewModel;
        private ObservableCollection<ViewModelBase> _pageViewModels;

        #region Constructor

        public ApplicationViewModel(ObservableCollection<ViewModelBase> listOfVM, ViewModelBase firstVM)
        {
            _pageViewModels = listOfVM;
            _currentPageViewModel = firstVM;
            _changePageCommand = new DelegateCommand(ExecuteChangePageCommand, CanExecuteChangePageCommand);
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
            if (!_pageViewModels.Contains(vMBase))
            {
                _pageViewModels.Add(vMBase);
            }

            _currentPageViewModel = vMBase;
        }

        #endregion

    }
}
