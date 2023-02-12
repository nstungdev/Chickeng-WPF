using Chickeng.GUI.Commands;
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
    /// Interaction logic for FloatEffectButtonUC.xaml
    /// </summary>
    public partial class FloatEffectButtonUC : UserControl
    {
        public FloatEffectButtonUC()
        {
            InitializeComponent();
        }
        public Brush IconColor { get => pthIcon.Fill; set => pthIcon.Fill = value; }
        public Geometry IconData { get => pthIcon.Data; set => pthIcon.Data = value; }
        public double EffectWidth => Width + 5;
        public double EffectHeight => Width + 5;
        public double OriginWidth => Width;
        public double OriginHeigth => Height;

        public event Action<EventArgs>? Click;

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

        private void pnContainer_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Click?.Invoke(new EventArgs());
        }
    }
}
