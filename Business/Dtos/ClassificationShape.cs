using Geometry.Values;

namespace Business.Dtos
{
    public class ClassificationShape
    {
        public ShapeType ShapeType { get; set; }
        public int Quantity { get; set; }
        public decimal TotalArea { get; set; }
        public decimal TotalPerimeter { get; set; }
    }
}
