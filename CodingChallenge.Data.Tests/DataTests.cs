using System.Collections.Generic;

using NUnit.Framework;

using Business.Contracts;
using Business.Services;
using CodingChallenge.Data.Classes;
using Geometry.Contracts;
using Geometry.Shapes;
using Resources.Contracts;
using Resources.Services;
using Resources.Values;

namespace CodingChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        [TestCase]
        public void TestResumenListaVacia()
        {
            ILocations locations = new Locations();

            IGeometricShapesClassifier classifier = new ShapesReportClassifier();

            IShapesReportTemplateFactory factory = new ShapesReportTemplateFactory(
                locations);

            IClassificationShapesFormatter formatter = new ShapesReportFormatter(locations);

            IShapesReportBuilder builder = new ShapesReportBuilder(factory, classifier, formatter);

            var shapes = new List<IGeometricShape>();

            var service = new FormaGeometrica(builder);

            var result = service.Imprimir(shapes, Language.Spanish);

            var expectedResult = "<h1>Lista vacía de formas!</h1>";

            Assert.AreEqual(expectedResult, result);
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            ILocations locations = new Locations();

            IGeometricShapesClassifier classifier = new ShapesReportClassifier();

            IShapesReportTemplateFactory factory = new ShapesReportTemplateFactory(
                locations);

            IClassificationShapesFormatter formatter = new ShapesReportFormatter(locations);

            IShapesReportBuilder builder = new ShapesReportBuilder(factory, classifier, formatter);

            var shapes = new List<IGeometricShape>();

            var service = new FormaGeometrica(builder);

            var result = service.Imprimir(shapes, Language.English);

            var expectedResult = "<h1>Empty list of shapes!</h1>";

            Assert.AreEqual(expectedResult, result);
        }

        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            ILocations locations = new Locations();

            IGeometricShapesClassifier classifier = new ShapesReportClassifier();

            IShapesReportTemplateFactory factory = new ShapesReportTemplateFactory(
                locations);

            IClassificationShapesFormatter formatter = new ShapesReportFormatter(locations);

            IShapesReportBuilder builder = new ShapesReportBuilder(factory, classifier, formatter);

            var shapes = new List<IGeometricShape>
            {
                new Square(5),
            };

            var service = new FormaGeometrica(builder);

            var result = service.Imprimir(shapes, Language.Spanish);

            var expectedResult = "<h1>Reporte de Formas</h1>1 Cuadrado | Área 25 | Perímetro 20 " +
                "<br/>TOTAL:<br/>1 formas Perímetro 20 Área 25";

            Assert.AreEqual(expectedResult, result);
        }

        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            ILocations locations = new Locations();

            IGeometricShapesClassifier classifier = new ShapesReportClassifier();

            IShapesReportTemplateFactory factory = new ShapesReportTemplateFactory(
                locations);

            IClassificationShapesFormatter formatter = new ShapesReportFormatter(locations);

            IShapesReportBuilder builder = new ShapesReportBuilder(factory, classifier, formatter);

            var shapes = new List<IGeometricShape>
            {
                new Square(5),
                new Square(1),
                new Square(3),
            };

            var service = new FormaGeometrica(builder);

            var result = service.Imprimir(shapes, Language.English);

            var expectedResult = "<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 " +
                "<br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35";

            Assert.AreEqual(expectedResult, result);
        }

        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            ILocations locations = new Locations();

            IGeometricShapesClassifier classifier = new ShapesReportClassifier();

            IShapesReportTemplateFactory factory = new ShapesReportTemplateFactory(
                locations);

            IClassificationShapesFormatter formatter = new ShapesReportFormatter(locations);

            IShapesReportBuilder builder = new ShapesReportBuilder(factory, classifier, formatter);

            var shapes = new List<IGeometricShape>
            {
                new Square(5),
                new Circle(3),
                new EquilateralTriangle(4),
                new Square(2),
                new EquilateralTriangle(9),
                new Circle(2.75m),
                new EquilateralTriangle(4.2m),
            };

            var service = new FormaGeometrica(builder);

            var result = service.Imprimir(shapes, Language.English);

            var expectedResult = "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 " +
                "<br/>2 Circles | Area 13,01 | Perimeter 18,06 " +
                "<br/>3 Triangles | Area 49,64 | Perimeter 51,6 " +
                "<br/>TOTAL:<br/>7 shapes Perimeter 97,66 Area 91,65";

            Assert.AreEqual(expectedResult,result);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            ILocations locations = new Locations();

            IGeometricShapesClassifier classifier = new ShapesReportClassifier();

            IShapesReportTemplateFactory factory = new ShapesReportTemplateFactory(
                locations);

            IClassificationShapesFormatter formatter = new ShapesReportFormatter(locations);

            IShapesReportBuilder builder = new ShapesReportBuilder(factory, classifier, formatter);

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

            var service = new FormaGeometrica(builder);

            var result = service.Imprimir(shapes, Language.Spanish);

            var expectedResult = "<h1>Reporte de Formas</h1>2 Cuadrados | Área 29 | Perímetro 28" +
                " <br/>2 Círculos | Área 13,01 | Perímetro 18,06 " +
                "<br/>3 Triángulos | Área 49,64 | Perímetro 51,6 " +
                "<br/>TOTAL:<br/>7 formas Perímetro 97,66 Área 91,65";

            Assert.AreEqual(expectedResult, result);
        }
    }
}
