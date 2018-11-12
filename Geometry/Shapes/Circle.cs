using System;

using Geometry.Contracts;
using Geometry.Values;

namespace Geometry.Shapes
{
    public class Circle : IGeometricShape
    {
        readonly decimal _diameter;

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

        public ShapeType GetShapeType()
        {
            return ShapeType.Circle;
        }
    }
}
