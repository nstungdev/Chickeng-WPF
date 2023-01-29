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
    /// Interaction logic for MenuCardUC.xaml
    /// </summary>
    public partial class MenuCardUC : UserControl
    {
        public MenuCardUC()
        {
            InitializeComponent();
        }

        #region Register Binding Properties
        public static readonly DependencyProperty SubheadProperty = DependencyProperty.Register(
            "Subhead",
            typeof(string),
            typeof(MenuCardUC),
            new PropertyMetadata(string.Empty, new PropertyChangedCallback(OnSubheadChanged)));
        private static void OnSubheadChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var menuCard = d as MenuCardUC;
            if (menuCard?.txt_subhead != null)
            {
                menuCard.txt_subhead.Text = e.NewValue as string;
            }
        }

        public static readonly DependencyProperty BadgeProperty = DependencyProperty.Register(
            "Badge",
            typeof(string),
            typeof(MenuCardUC),
            new PropertyMetadata(string.Empty, new PropertyChangedCallback(OnBadgeChanged)));
        private static void OnBadgeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var menuCard = d as MenuCardUC;
            if (menuCard?.txt_badge != null)
            {
                menuCard.txt_badge.Text = e.NewValue as string;
            }
        }

        public static DependencyProperty CommandProperty = DependencyProperty.Register(
            "Command", 
            typeof(ICommand), 
            typeof(MenuCardUC), 
            new PropertyMetadata(null));
        #endregion

        public string? Title
        {
            get => txt_title.Text;
            set => txt_title.Text = value;
        }

        public string? Subhead
        {
            get => txt_subhead.Text;
            set => txt_subhead.Text = value;
        }

        public string? Badge
        {
            get => txt_badge.Text;
            set => txt_badge.Text = value;
        }

        public ICommand? Command { get; set; }
    }
}
