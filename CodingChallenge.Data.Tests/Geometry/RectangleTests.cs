using System;

using NUnit.Framework;

using Geometry.Shapes;

namespace CodingChallenge.Data.Tests.Geometry
{
    [TestFixture]
    public class RectangleTests
    {
        [TestCase]
        public void CalcaulteAreaTest()
        {
            var shape = new Rectangle(3.75m, 8.25m);

            var result = shape.CalculateArea();

            var expectedResult = 30.94m;

            Assert.AreEqual(expectedResult, Math.Round(result, 2));
        }

        [TestCase]
        public void CalcaultePerimterTest()
        {
            var shape = new Rectangle(7.35m, 4.12m);

            var result = shape.CalculatePerimeter();

            var expectedResult = 22.94m;

            Assert.AreEqual(expectedResult, Math.Round(result, 2));
        }
    }
}
