using System;

using NUnit.Framework;

using Geometry.Shapes;

namespace CodingChallenge.Data.Tests.Geometry
{
    [TestFixture]
    public class IsoscelesTrapezoidTest
    {
        [TestCase]
        public void CalculateAreaTest()
        {
            var shape = new IsoscelesTrapezoid(2, 1.5m, 4.75m);

            var result = shape.CalculateArea();

            var expectedResult = 3.64m;

            Assert.AreEqual(expectedResult, Math.Round(result, 2));
        }

        [TestCase]
        public void CalculatePerimeterTest()
        {
            var shape = new IsoscelesTrapezoid(3.25m, 2.75m, 5.5m);

            var result = shape.CalculatePerimeter();

            var expectedResult = 14.75m;

            Assert.AreEqual(expectedResult, result);
        }
    }
}
