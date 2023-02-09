using Chickeng.GUI.Stores;
using Chickeng.GUI.ViewModels;
using System;
using System.Collections.Generic;
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

namespace Chickeng.GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly NavigationService<HomeViewModel> _homeNavigationService;
        public MainWindow(NavigationService<HomeViewModel> homeNavigationService)
        {
            InitializeComponent();
            _homeNavigationService = homeNavigationService;
        }

        private void Quit(EventArgs obj)
        {
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var dialog = MessageBox.Show("Are you sure?", "Exit Chickeng", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (dialog == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }

        private void BackToHome(EventArgs obj)
        {
            _homeNavigationService.Navigate();
        }
    }
}
