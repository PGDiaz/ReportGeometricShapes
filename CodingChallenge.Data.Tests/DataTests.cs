using System.Collections.Generic;

using NUnit.Framework;

using CodingChallenge.Data.Classes;
using Geometry.Contracts;
using Geometry.Shapes;

namespace CodingChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        [TestCase]
        public void TestResumenListaVacia()
        {
            var shapes = new List<IGeometricShape>();

            var result = FormaGeometrica.Imprimir(shapes, 1);

            var expectedResult = "<h1>Lista vacía de formas!</h1>";

            Assert.AreEqual(expectedResult, result);
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            var shapes = new List<IGeometricShape>();

            var result = FormaGeometrica.Imprimir(shapes, 2);

            var expectedResult = "<h1>Empty list of shapes!</h1>";

            Assert.AreEqual(expectedResult, result);
        }

        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            var shapes = new List<IGeometricShape>
            {
                new Square(5),
            };

            var result = FormaGeometrica.Imprimir(shapes, FormaGeometrica.Castellano);

            var expectedResult = "<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 " +
                "<br/>TOTAL:<br/>1 formas Perimetro 20 Area 25";

            Assert.AreEqual(expectedResult, result);
        }

        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            var shapes = new List<IGeometricShape>
            {
                new Square(5),
                new Square(1),
                new Square(3),
            };

            var result = FormaGeometrica.Imprimir(shapes, FormaGeometrica.Ingles);

            var expectedResult = "<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 " +
                "<br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35";

            Assert.AreEqual(expectedResult, result);
        }

        [TestCase]
        public void TestResumenListaConMasTipos()
        {
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

            var result = FormaGeometrica.Imprimir(shapes, FormaGeometrica.Ingles);

            var expectedResult = "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 " +
                "<br/>2 Circles | Area 13,01 | Perimeter 18,06 " +
                "<br/>3 Triangles | Area 49,64 | Perimeter 51,6 " +
                "<br/>TOTAL:<br/>7 shapes Perimeter 97,66 Area 91,65";

            Assert.AreEqual(expectedResult,result);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellano()
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

            var result = FormaGeometrica.Imprimir(shapes, FormaGeometrica.Castellano);

            var expectedResult = "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28" +
                " <br/>2 Círculos | Area 13,01 | Perimetro 18,06 " +
                "<br/>3 Triángulos | Area 49,64 | Perimetro 51,6 " +
                "<br/>TOTAL:<br/>7 formas Perimetro 97,66 Area 91,65";

            Assert.AreEqual(expectedResult, result);
        }
    }
}
