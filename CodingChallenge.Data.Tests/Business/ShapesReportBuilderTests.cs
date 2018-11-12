using System;
using System.Collections.Generic;

using Moq;

using NUnit.Framework;

using Business.Contracts;
using Business.Services;
using Geometry.Contracts;
using Geometry.Shapes;
using Resources.Contracts;
using Resources.Services;
using Resources.Values;

namespace CodingChallenge.Data.Tests.Business
{
    [TestFixture]
    public class ShapesReportBuilderTests
    {
        [TestCase]
        public void GeometricShapesIsNullTest()
        {
            var mockFactory = new Mock<IShapesReportTemplateFactory>();
            var mockClassifier = new Mock<IGeometricShapesClassifier>();
            var mockFormatter = new Mock<IClassificationShapesFormatter>();

            IList<IGeometricShape> shapes = null;

            var service = new ShapesReportBuilder(
                mockFactory.Object,
                mockClassifier.Object,
                mockFormatter.Object);

            Assert.Throws<ArgumentNullException>(() => service.Build(shapes, Language.English));
        }

        [TestCase]
        public void FrenchReportWithMultipleShapesTest()
        {
            ILocations locations = new Locations();

            IGeometricShapesClassifier classifier = new ShapesReportClassifier();

            IShapesReportTemplateFactory factory = new ShapesReportTemplateFactory(
                locations);

            IClassificationShapesFormatter formatter = new ShapesReportFormatter(locations);

            var shapes = new List<IGeometricShape>
            {
                new Square( 5),
                new Rectangle(7.35m, 4.12m),
                new IsoscelesTrapezoid(2, 3, 5),
                new Square(2),
            };

            var service = new ShapesReportBuilder(factory, classifier, formatter);

            var result = service.Build(shapes, Language.French);

            var expectedResult = "<h1>Rapport de formes</h1>" +
                "2 Des carrés | Superficie 29 | Périmètre 28 <br/>" +
                "1 Rectangle | Superficie 30,28 | Périmètre 22,94 <br/>" +
                "1 Trapèze | Superficie 6,93 | Périmètre 12 <br/>" +
                "TOTAL:<br/>4 formes Périmètre 62,94 Superficie 66,21";

            Assert.AreEqual(expectedResult, result);
        }
    }
}
