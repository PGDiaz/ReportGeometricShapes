using System.Collections.Generic;
using System.Linq;

using Business.Dtos;
using Geometry.Values;

namespace Business.Mappers
{
    public static class ShapesReportFormatMapper
    {
        public static ShapeReportFoot ConvertToShapeReportFoot(
            this IEnumerable<ClassificationShape> classifiedShapes)
        {
            return new ShapeReportFoot
            {
                TotalQuantityShapes = classifiedShapes.Sum(cs => cs.Quantity),
                TotalShapesArea = classifiedShapes.Sum(cs => cs.TotalArea),
                TotalShapesPerimeter = classifiedShapes.Sum(cs => cs.TotalPerimeter),
            };
        }

        public static IEnumerable<ShapeReportBodyLine> ConvertToShapeReportBody(
            this IEnumerable<ClassificationShape> classifiedShapes,
            IDictionary<ShapeType, string> shapeTranslations)
        {
            return classifiedShapes.Select(cs => new ShapeReportBodyLine
            {
                ShapeTypeName = shapeTranslations[cs.ShapeType],
                QuantityShapes = cs.Quantity,
                ShapesArea = cs.TotalArea,
                ShapesPerimeter = cs.TotalPerimeter,
            });
        }
    }
}
