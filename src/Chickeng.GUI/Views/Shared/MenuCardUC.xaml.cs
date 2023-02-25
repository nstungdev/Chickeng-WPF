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
        // title Subhead
        public static readonly DependencyProperty SubheadProperty = DependencyProperty.Register(
            nameof(Subhead),
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

        // title Badge
        public static readonly DependencyProperty BadgeProperty = DependencyProperty.Register(
            nameof(Badge),
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

        // title register
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
            nameof(Title),
            typeof(string),
            typeof(MenuCardUC),
            new PropertyMetadata(string.Empty, new PropertyChangedCallback(OnTitleChanged)));
        private static void OnTitleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var menuCard = d as MenuCardUC;
            if (menuCard?.txt_title != null)
            {
                menuCard.txt_title.Text = e.NewValue as string;
            }
        }

        public static DependencyProperty CommandProperty = DependencyProperty.Register(
            nameof(Command), 
            typeof(ICommand), 
            typeof(MenuCardUC), 
            new PropertyMetadata(null));
        #endregion

        #region Properties
        public string? Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public string? Subhead
        {
            get => (string)GetValue(SubheadProperty);
            set => SetValue(SubheadProperty, value);
        }

        public string? Badge
        {
            get => (string)GetValue(BadgeProperty);
            set => SetValue(BadgeProperty, value);
        }
        #endregion

        #region Commands
        public ICommand? Command { get; set; }
        #endregion
    }
}
