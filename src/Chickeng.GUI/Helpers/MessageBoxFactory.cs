using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Chickeng.GUI.Helpers
{
    public class MessageBoxFactory
    {
        public static void ShowInfoBox(string message)
        {
            string caption = "Notification";
            MessageBox.Show(message
                , caption
                , MessageBoxButton.OK
                , MessageBoxImage.Information);
        }

        public static void ShowErrorBox(string message)
        {
            string caption = "Error";
            MessageBox.Show(message
                , caption
                , MessageBoxButton.OK
                , MessageBoxImage.Error);
        }
    }
}
