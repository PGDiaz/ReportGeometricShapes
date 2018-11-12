using System;

using Geometry.Contracts;
using Geometry.Values;

namespace Geometry.Shapes
{
    public class Rectangle : IGeometricShape
    {
        readonly decimal _firstSide;
        readonly decimal _secondSide;

        public Rectangle(decimal firstSide, decimal secondSide)
        {
            _firstSide = firstSide;
            _secondSide = secondSide;
        }

        public decimal CalculateArea()
        {
            return _firstSide * _secondSide;
        }

        public decimal CalculatePerimeter()
        {
            return _firstSide * 2 + _secondSide * 2;
        }

        public ShapeType GetShapeType()
        {
            return ShapeType.Rectangle;
        }
    }
}
