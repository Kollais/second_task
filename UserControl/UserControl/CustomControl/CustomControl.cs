using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using UserControl.ViewModel;

namespace UserControl.CustomControl
{
    public class CustomControl : Control
    {
        private const string ElementPlusButton = "PART_PlusButton";
        private const string ElementMinusButton = "PART_MinusButton";

        private Button _plusBtn;
        private Button _minusBtn;

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

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            Console.WriteLine("Template");

            this._minusBtn = this.Template.FindName("PART_MinusButton", this) as Button;
            if (_minusBtn != null)
                _minusBtn.Click += MinusBtn_Click;

            this._plusBtn = this.Template.FindName("PART_PlusButton", this) as Button;
            if (_plusBtn != null)
                _plusBtn.Click += PlusBtn_Click;

        }

        public void MinusBtn_Click(object sender, RoutedEventArgs e)
        {
            SliderValue--;
            Console.WriteLine("MinusWorks");
        }

        public void PlusBtn_Click(object sender, RoutedEventArgs e)
        {
            SliderValue++;
        }
    }
}
