using Chickeng.GUI.Helpers;
using Chickeng.GUI.Views.Shared;
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

namespace Chickeng.GUI.Views.Modules
{
    /// <summary>
    /// Interaction logic for VocabularyEditPhaseView.xaml
    /// </summary>
    public partial class VocabularyEditView : UserControl
    {
        public VocabularyEditView()
        {
            InitializeComponent();
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            var singleFormControls = WpfControlHelper.FindVisualChilds<FloatLableTextBoxUC>(this);
            var multiFormControls = WpfControlHelper.FindVisualChilds<FloatLableMultiLineTextBoxUC>(this);
            foreach (var control in singleFormControls)
            {
                control.FormValue = string.Empty;
            }

            foreach (var control in multiFormControls)
            {
                control.FormValue = string.Empty;
            }
        }

        private void Button_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            var data = DataContext;
        }
    }
}
