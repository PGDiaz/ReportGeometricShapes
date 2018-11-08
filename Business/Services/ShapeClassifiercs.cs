using System.Collections.Generic;
using System.Linq;

using Business.Contracts;
using Business.Dtos;
using Geometry.Contracts;
using Geometry.Shapes;

namespace Business.Services
{
    public class ShapeClassifiercs : IGeometricShapesClassifier
    {
        public IEnumerable<ClassificationShape> Classify(IEnumerable<IGeometricShape> shapes)
        {
            if (!shapes.Any())
            {
                return Enumerable.Empty<ClassificationShape>();
            }

            var squares = new ClassificationShape
            {
                Type = 1,
                Quantity = 0,
                TotalArea = decimal.Zero,
                TotalPerimeter = decimal.Zero,
            };

            var equilateralTriangles = new ClassificationShape
            {
                Type = 2,
                Quantity = 0,
                TotalArea = decimal.Zero,
                TotalPerimeter = decimal.Zero,
            };

            var circles = new ClassificationShape
            {
                Type = 3,
                Quantity = 0,
                TotalArea = decimal.Zero,
                TotalPerimeter = decimal.Zero,
            };

            foreach (var shape in shapes)
            {
                if (shape.GetType() == typeof(Square))
                {
                    Add(squares, shape);
                }

                if (shape.GetType() == typeof(Circle))
                {
                    Add(circles, shape);
                }

                if (shape.GetType() == typeof(EquilateralTriangle))
                {
                    Add(equilateralTriangles, shape);
                }
            }

            return new List<ClassificationShape>
            {
                squares,
                circles,
                equilateralTriangles,
            };
        }

        void Add(ClassificationShape classification, IGeometricShape shape)
        {
            classification.Quantity++;
            classification.TotalArea += shape.CalculateArea();
            classification.TotalPerimeter += shape.CalculatePerimeter();
        }
    }
}
