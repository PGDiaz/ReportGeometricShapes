namespace Geometry.Contracts
{
    public interface IGeometricShape
    {
        int Tipo();
        decimal CalculateArea();
        decimal CalculatePerimeter();
    }
}
