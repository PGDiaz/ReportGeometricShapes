using Geometry.Values;

namespace Geometry.Contracts
{
    public interface IGeometricShape
    {
        ShapeType GetShapeType();
        decimal CalculateArea();
        decimal CalculatePerimeter();
    }
}
