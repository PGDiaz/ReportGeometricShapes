using Geometry.Contracts;
using Geometry.Values;

namespace Geometry.Shapes
{
    public class Square : IGeometricShape
    {
        readonly decimal _side;

        public Square(decimal side)
        {
            _side = side;
        }

        public decimal CalculateArea()
        {
            return _side * _side;
        }

        public decimal CalculatePerimeter()
        {
            return _side * 4;
        }

        public ShapeType GetShapeType()
        {
            return ShapeType.Square;
        }
    }
}
