using BreakReminder.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BreakReminder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Page
    {
        public MainWindow()
        {
            //ObservableCollection<ViewModelBase> listOfVM = new ObservableCollection<ViewModelBase>{
            //    new ReminderViewModel()
            //};

            //DataContext = new ApplicationViewModel(listOfVM, listOfVM[0]);

            DataContext = new ReminderViewModel(this);
            InitializeComponent();
        }
    }
}
