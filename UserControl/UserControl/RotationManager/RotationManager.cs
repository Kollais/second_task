using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace UserControl.RotationManager
{
    public class RotationManager : DependencyObject
    {
        public static double GetAngle(DependencyObject obj)
        {
            return (double)obj.GetValue(AngleProperty);
        }

        public static void SetAngle(DependencyObject obj, double value)
        {
            obj.SetValue(AngleProperty, value);
        }

        public double Angle
        {
            get { return (double)GetValue(AngleProperty); }
            set { SetValue(AngleProperty, value); }
        }

        static FrameworkPropertyMetadata metadata = new FrameworkPropertyMetadata(0d, FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(OnAngleChanged));

        public static readonly DependencyProperty AngleProperty =
            DependencyProperty.RegisterAttached("Angle", typeof(double), typeof(RotationManager), metadata);

        static void OnAngleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var el = d as UIElement;
            if (el != null)
            {
                RotateTransform rt = new RotateTransform();
                DoubleAnimation animation = new DoubleAnimation();
                animation.From = (double)e.OldValue;
                animation.To = (double)e.NewValue;
                animation.Duration = new Duration(TimeSpan.FromSeconds(2));
                el.RenderTransform = rt;
                el.RenderTransformOrigin = new Point(0.5, 0.5);
                rt.BeginAnimation(RotateTransform.AngleProperty,animation);
            }
        }
    }
}
