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

namespace Chickeng.GUI.Views.Shared
{
    /// <summary>
    /// Interaction logic for FloatLableTextBoxUC.xaml
    /// </summary>
    public partial class FloatLableTextBoxUC : UserControl
    {
        public FloatLableTextBoxUC()
        {
            InitializeComponent();
        }
        #region EXPOSE PROPERTIES
        public string? Placeholder { get => lblPlaceholder.Text; set => lblPlaceholder.Text = value; }
        public string? Lable { get => lblFloatLabel.Text; set => lblFloatLabel.Text = value; }
        public string FormValue 
        { 
            get => (string)GetValue(FormValueProperty);
            set => SetValue(FormValueProperty, value);
        }
        public static readonly DependencyProperty FormValueProperty = DependencyProperty.Register(
            nameof(FormValue),
            typeof(string),
            typeof(FloatLableTextBoxUC),
            new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion
        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            pnContainer.RowDefinitions[0].Height = new GridLength(txtMain.FontSize);
            lblFloatLabel.FontSize = txtMain.FontSize - 3;
            lblFloatLabel.Visibility = txtMain.Text.Length == 0 
                ? Visibility.Hidden
                : Visibility.Visible;
        }

        private void txtMain_GotFocus(object sender, RoutedEventArgs e)
        {
            TransformToFocus();
        }

        private void txtMain_LostFocus(object sender, RoutedEventArgs e)
        {
            TransformToLostFocus();
        }

        private void txtMain_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtMain.Text.Length == 0)
            {
                lblPlaceholder.Visibility = Visibility.Visible;
                lblFloatLabel.Visibility = Visibility.Hidden;
            }
            else
            {
                lblPlaceholder.Visibility = Visibility.Hidden;
                lblFloatLabel.Visibility = Visibility.Visible;
            }
        }

        private void TransformToLostFocus()
        {
            brdWrapee.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#86b7fe"));
        }

        private void TransformToFocus()
        {
            brdWrapee.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF3E62D2"));
        }
    }
}
