using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows;

namespace MonteCarlo_MVVM
{
    public class MyModel
    {
        private const double _radius = 100;
        private List<Point> _circlePoints = new List<Point>();
        private List<Point> _squarePoints = new List<Point>();
        private static readonly Random getrandom = new Random();

        public double Radius()
        {
            return _radius;
        }

        public int CirclePoints()
        {
            return _circlePoints.Count();
        }

        public int SquarePoints()
        {
            return _squarePoints.Count();
        }

        public Point GenerateAndAddPoint()
        {
            Point point = GeneratePoint();

            if (IsInsideTheCircle(point))
            {
                _circlePoints.Add(point);
            }
            else 
            {
                _squarePoints.Add(point);
            }
            return point;
        }

        private Boolean IsInsideTheCircle(Point point)
        {
            return (Math.Sqrt(Math.Pow(point.X, 2) + Math.Pow(point.Y, 2)) <= _radius);
        }

        private Double RandomMinus1To1()
        {
            return 2.0 * (getrandom.NextDouble() - 0.5);
        }

        private Point GeneratePoint()
        {
            return new Point(_radius * RandomMinus1To1(), _radius * RandomMinus1To1());
        }
    }
}
