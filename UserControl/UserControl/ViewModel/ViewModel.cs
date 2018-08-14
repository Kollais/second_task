using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace UserControl.ViewModel
{
    class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private int _slidervalue = 0;
        public int SliderValue
        {
            get { return _slidervalue; }
            set { _slidervalue = value; OnPropertyChanged("SliderValue"); }
        }

        private double _angle = 0;
        public double Angle
        {
            get { return _angle; }
            set { _angle = value; OnPropertyChanged("Angle"); }
        }

        public ICommand RotateClick
        {
            get { return new RelayCommand(param => rotateClick()); }
        }

        private void rotateClick()
        {
            Random rand = new Random();
            int n = rand.Next(1, 360);
            Angle = (double)n;
        }
    }

    public class RelayCommand : ICommand
    {
        private Action<object> commandTask;

        public RelayCommand(Action<object> extCommand)
        {
            commandTask = extCommand;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            commandTask(parameter);
        }
    }
}
