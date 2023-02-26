using Chickeng.GUI.Stores;
using Chickeng.GUI.ViewModels;
using System.Windows;

namespace Chickeng.GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(NavigationService<HomeViewModel> homeNavigationService)
        {
            InitializeComponent();
        }
    }
}
