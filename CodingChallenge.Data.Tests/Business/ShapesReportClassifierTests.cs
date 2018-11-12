using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;

using Business.Services;
using Geometry.Contracts;
using Geometry.Shapes;

namespace CodingChallenge.Data.Tests.Business
{
    [TestFixture]
    public class ShapesReportClassifierTests
    {
        [TestCase]
        public void CountShapesClassificationTest()
        {
            var shapes = new List<IGeometricShape>
            {
                new Square( 5),
                new Circle(3),
                new EquilateralTriangle(4),
                new Square(2),
                new EquilateralTriangle(9),
                new Circle(2.75m),
                new EquilateralTriangle(4.2m)
            };

            var expectedResult = 3;

            var service = new ShapesReportClassifier();

            var result = service.Classify(shapes);

            Assert.AreEqual(expectedResult, result.Count());
        }

        [TestCase]
        public void EmptyClassificationShapesTest()
        {
            var shapes = Enumerable.Empty<IGeometricShape>();

            var service = new ShapesReportClassifier();

            var result = service.Classify(shapes);

            CollectionAssert.IsEmpty(result);
        }
    }
}
