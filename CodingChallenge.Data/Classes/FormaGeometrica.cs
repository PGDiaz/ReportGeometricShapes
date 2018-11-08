using System.Collections.Generic;
using System.Linq;
using System.Text;

using Business.Dtos;
using Business.Services;
using Geometry.Contracts;

namespace CodingChallenge.Data.Classes
{
    public class FormaGeometrica
    {
        #region Formas

        public const int Cuadrado = 1;
        public const int TrianguloEquilatero = 2;
        public const int Circulo = 3;
        public const int Trapecio = 4;

        #endregion

        #region Idiomas

        public const int Castellano = 1;
        public const int Ingles = 2;

        #endregion

        public static string Imprimir(IList<IGeometricShape> shapes, int language)
        {
            var sb = new StringBuilder();

            if (!shapes.Any())
            {
                if (language == Castellano)
                    sb.Append("<h1>Lista vacía de formas!</h1>");
                else
                    sb.Append("<h1>Empty list of shapes!</h1>");
            }
            else
            {
                if (language == Castellano)
                    sb.Append("<h1>Reporte de Formas</h1>");
                else
                    // default es inglés
                    sb.Append("<h1>Shapes report</h1>");

                var classifier = new ShapeClassifiercs();

                var classifications = classifier.Classify(shapes);

                foreach (var classification in classifications)
                {
                    sb.Append(ObtenerLinea(classification, language));
                }

                sb.Append("TOTAL:<br/>");

                sb.Append(classifications.Sum(c => c.Quantity) + " " +
                    (language == Castellano ? "formas" : "shapes") + " ");

                sb.Append((language == Castellano ? "Perimetro " : "Perimeter ") +
                    classifications.Sum(c => c.TotalPerimeter).ToString("#.##") + " ");

                sb.Append("Area " + (classifications.Sum(c => c.TotalArea)).ToString("#.##"));
            }

            return sb.ToString();
        }

        static string ObtenerLinea(ClassificationShape classification, int idioma)
        {
            if (classification.Quantity > 0)
            {
                if (idioma == Castellano)
                {
                    return $"{classification.Quantity} {TraducirForma(classification.Type, classification.Quantity, idioma)} | Area {classification.TotalArea:#.##} | Perimetro {classification.TotalPerimeter:#.##} <br/>";
                }

                return $"{classification.Quantity} {TraducirForma(classification.Type, classification.Quantity, idioma)} | Area {classification.TotalArea:#.##} | Perimeter {classification.TotalPerimeter:#.##} <br/>";
            }

            return string.Empty;
        }

        static string TraducirForma(int tipo, int cantidad, int idioma)
        {
            switch (tipo)
            {
                case Cuadrado:
                    if (idioma == Castellano) return cantidad == 1 ? "Cuadrado" : "Cuadrados";
                    else return cantidad == 1 ? "Square" : "Squares";
                case Circulo:
                    if (idioma == Castellano) return cantidad == 1 ? "Círculo" : "Círculos";
                    else return cantidad == 1 ? "Circle" : "Circles";
                case TrianguloEquilatero:
                    if (idioma == Castellano) return cantidad == 1 ? "Triángulo" : "Triángulos";
                    else return cantidad == 1 ? "Triangle" : "Triangles";
            }

            return string.Empty;
        }
    }
}
