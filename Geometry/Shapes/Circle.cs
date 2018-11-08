using System;

using Geometry.Contracts;

namespace Geometry.Shapes
{
    public class Circle : IGeometricShape
    {
        decimal _diameter;

        public Circle(decimal diameter)
        {
            _diameter = diameter;
        }

        public decimal CalculateArea()
        {
            return (decimal)Math.PI * _diameter * _diameter / 4;
        }

        public decimal CalculatePerimeter()
        {
            return (decimal)Math.PI * _diameter;
        }
    }
}
