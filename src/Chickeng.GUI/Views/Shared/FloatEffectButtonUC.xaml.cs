using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Chickeng.GUI.Views.Shared
{
    /// <summary>
    /// Interaction logic for FloatEffectButtonUC.xaml
    /// </summary>
    public partial class FloatEffectButtonUC : UserControl
    {
        public FloatEffectButtonUC()
        {
            InitializeComponent();
        }

        #region Register Properties
        public static DependencyProperty CommandProperty = DependencyProperty.Register(
            nameof(Command),
            typeof(ICommand),
            typeof(FloatEffectButtonUC),
            new PropertyMetadata(null));
        public ICommand? Command { get; set; }
        #endregion

        public Brush IconColor { get => pthIcon.Fill; set => pthIcon.Fill = value; }
        public Geometry IconData { get => pthIcon.Data; set => pthIcon.Data = value; }
        public double EffectWidth => Width + 5;
        public double EffectHeight => Width + 5;
        public double OriginWidth => Width;
        public double OriginHeigth => Height;

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            var ucHeight = this.Height;
            var ucWidth = this.Width;

            pnContainer.Height = ucHeight;
            pnContainer.Width = ucWidth;

            canvas.Height = ucHeight;
            canvas.Width = ucWidth;

            pthIcon.Height = ucHeight;
            pthIcon.Width = ucWidth;
        }

        private void canvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            pthIcon.Height = canvas.Height;
            pthIcon.Width = canvas.Width;
        }
    }
}
