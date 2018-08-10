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

namespace UserControl.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ResourceDictionary style = new ResourceDictionary();
            style.Source = new Uri("../Styles/DefaultStyle.xaml",UriKind.Relative);
            this.Resources.MergedDictionaries.Clear();
            this.Resources.MergedDictionaries.Add(style);
        }

        private int _slidervalue = 0;
        public int SliderValue
        {
            get { return _slidervalue; } 
            set { _slidervalue = value; }
        }

        private int _angle = 0;
        public int Angle
        {
            get { return _angle; }
            set { _angle = value; }
        }

        private void MinusClick(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Minus Works");
        }

        private void PlusClick(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Plus Works");
        }

        private void RotateClick(object sender, RoutedEventArgs e)
        {
            Random rand = new Random();
            int n = rand.Next(0, 359);
            Angle = n;
            Console.WriteLine("Rotate Works");
        }
    }

    public class CustomControl : Control
    {
        public static readonly DependencyProperty SliderValueProperty =
            DependencyProperty.Register("SliderValue", typeof(int), typeof(CustomControl), 
                new PropertyMetadata(null));

        public int SliderValue
        {
            get { return (int)GetValue(SliderValueProperty); }
            set { SetValue(SliderValueProperty, value); }
        }

        static CustomControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomControl), 
                new FrameworkPropertyMetadata(typeof(CustomControl)));
        }
    }

    public class RotationManager : ContentControl
    {
        public static readonly DependencyProperty AngleProperty =
            DependencyProperty.RegisterAttached("Angle", typeof(double), typeof(RotationManager),
                new PropertyMetadata(null));

        public double Angle
        {
            get { return (double)GetValue(AngleProperty); }
            set { SetValue(AngleProperty, value); }
        }

        static RotationManager()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(RotationManager),
                new FrameworkPropertyMetadata(typeof(RotationManager)));
        }
    }
}
