using System;

using Geometry.Contracts;
using Geometry.Values;

namespace Geometry.Shapes
{
    public class EquilateralTriangle : IGeometricShape
    {
        readonly decimal _side;

        public EquilateralTriangle(decimal side)
        {
            _side = side;
        }

        public decimal CalculateArea()
        {
            return ((decimal)Math.Sqrt(3) / 4) * _side * _side;
        }

        public decimal CalculatePerimeter()
        {
            return _side * 3;
        }

        public ShapeType GetShapeType()
        {
            return ShapeType.EquilateralTriangle;
        }
    }
}
