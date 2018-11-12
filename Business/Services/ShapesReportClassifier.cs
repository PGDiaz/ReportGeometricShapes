using System.Collections.Generic;
using System.Linq;

using Business.Contracts;
using Business.Dtos;
using Geometry.Contracts;

namespace Business.Services
{
    public class ShapesReportClassifier : IGeometricShapesClassifier
    {
        public IEnumerable<ClassificationShape> Classify(IEnumerable<IGeometricShape> shapes)
        {
            if (!shapes.Any())
            {
                return Enumerable.Empty<ClassificationShape>();
            }

            var groupShapesByType = shapes.GroupBy(s => s.GetShapeType());

            return groupShapesByType.Select(group => new ClassificationShape
            {
                ShapeType = group.Key,
                Quantity = group.Count(),
                TotalArea = group.Sum(shape => shape.CalculateArea()),
                TotalPerimeter = group.Sum(shape => shape.CalculatePerimeter()),
            });
        }
    }
}
