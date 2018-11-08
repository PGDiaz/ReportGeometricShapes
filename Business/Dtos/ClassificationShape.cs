using System;

namespace Business.Dtos
{
    public class ClassificationShape
    {
        public Type ShapeType { get; set; }
        public int Quantity { get; set; }
        public decimal TotalArea { get; set; }
        public decimal TotalPerimeter { get; set; }
    }
}
