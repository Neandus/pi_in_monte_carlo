using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MonteCarlo_MVVM
{
    public class BaseItemVM
    {
        public double Left { get; set; }
        public double Top { get; set; }
        public int ZIndex { get; set; }
    }

    public class CircleVM : BaseItemVM
    {
        public double Diameter { get; set; }
    }

    public class SquareVM : BaseItemVM
    {
        public double Side { get; set; }
    }

    public class PointVM : CircleVM
    {
        public string Color { get; set; }
    }

    public class MyViewModel : ObservableObject
    {
        private readonly MyModel _myModel = new MyModel();
        private double _piValue = 0.0;
        private double _pointDiameter = 1.0;
 
        public ObservableCollection<BaseItemVM> Items { get; set; }
        
        public MyViewModel()
        {
            Items = new ObservableCollection<BaseItemVM> 
            {
                new CircleVM{ Diameter=CircleDiameter, Left=0, Top=0, ZIndex=2},
                new SquareVM{ Side=SquareSide, Left=0, Top=0, ZIndex=1}              
            };
        }
        
        public double CanvasWidth
        {
            get
            {
                return Math.Max(CircleDiameter, SquareSide);
            }
        }

        public double CanvasHeight 
        {
            get
            {
                return Math.Max(CircleDiameter, SquareSide);
            }
        }

        public ICommand AddPointCommand
        {
            get { return new DelegateCommand(() => AddPoint(1)); }
        }

        public ICommand Add10PointsCommand
        {
            get { return new DelegateCommand(Add_10_Points); }
        }

        public double PiValue
        {
            get { return _piValue; }
            set
            {
                _piValue = value;
                RaisePropertyChangedEvent("PiValue");
            }
        }

        private double CircleDiameter
        {
            get { return (2 * _myModel.Radius()) + _pointDiameter; }
        }

        private double SquareSide
        {
            get { return (2 * _myModel.Radius()) + _pointDiameter; }
        }

        private void AddPoint(int maxCount = 1)
        {
            for (int i = 0; i < maxCount; i++)
            {
                double offset = _myModel.Radius();
                Point point =_myModel.GenerateAndAddPoint();

                double left = point.X + offset;
                double top = point.Y + offset;
                System.Console.WriteLine("left:" + left.ToString() + " top:" + top.ToString());

                Items.Add(new PointVM { Left=left, Top=top, ZIndex=3,
                                        Diameter=_pointDiameter, Color="Red"});
            }
            CalculatePi();
        }

        private void Add_10_Points()
        {
            AddPoint(10);
        }

        private void CalculatePi()
        {
            if (_myModel.CirclePoints().Equals(0) && _myModel.SquarePoints().Equals(0)) 
                return;
            PiValue = (double)(4.0 * _myModel.CirclePoints() / (_myModel.CirclePoints() + _myModel.SquarePoints()));
        }
    }
}
