using Geometry.Contracts;

namespace Geometry.Shapes
{
    public class Square : IGeometricShape
    {
        decimal _side;

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

        public int Tipo()
        {
            return 1;
        }
    }
}
