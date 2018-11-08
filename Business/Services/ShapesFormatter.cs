using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Business.Contracts;
using Business.Dtos;
using Geometry.Shapes;

namespace Business.Services
{
    public class ShapeFormatter : IClassificationShapesFormatter
    {
        const int Castellano = 1;
        const int Ingles = 2;

        public string Format(IEnumerable<ClassificationShape> classifications, int language)
        {
            var format = new StringBuilder();

            foreach (var classification in classifications)
            {
                format.Append(GetFormattedLine(classification, language));
            }

            format.Append("TOTAL:<br/>");

            format.Append(classifications.Sum(c => c.Quantity) + " " +
                (language == Castellano ? "formas" : "shapes") + " ");

            format.Append((language == Castellano ? "Perimetro " : "Perimeter ") +
                classifications.Sum(c => c.TotalPerimeter).ToString("#.##") + " ");

            format.Append("Area " + (classifications.Sum(c => c.TotalArea)).ToString("#.##"));

            return format.ToString();
        }

        static string GetFormattedLine(ClassificationShape classification, int language)
        {
            if (classification.Quantity > 0)
            {
                if (language == Castellano)
                {
                    return $"{classification.Quantity} {TranslateAndFormat(classification.ShapeType, classification.Quantity, language)} | Area {classification.TotalArea:#.##} | Perimetro {classification.TotalPerimeter:#.##} <br/>";
                }

                return $"{classification.Quantity} {TranslateAndFormat(classification.ShapeType, classification.Quantity, language)} | Area {classification.TotalArea:#.##} | Perimeter {classification.TotalPerimeter:#.##} <br/>";
            }

            return string.Empty;
        }

        static string TranslateAndFormat(Type shapeType, int quantity, int language)
        {
            if (shapeType == typeof(Square))
            {
                if (language == Castellano)
                {
                    return quantity == 1 ? "Cuadrado" : "Cuadrados";
                }
                else
                {
                    return quantity == 1 ? "Square" : "Squares";
                }
            }

            if (shapeType == typeof(Circle))
            {
                if (language == Castellano)
                {
                    return quantity == 1 ? "Círculo" : "Círculos";
                }
                else
                {
                    return quantity == 1 ? "Circle" : "Circles";
                }
            }

            if (shapeType == typeof(EquilateralTriangle))
            {
                if (language == Castellano)
                {
                    return quantity == 1 ? "Triángulo" : "Triángulos";
                }
                else
                {
                    return quantity == 1 ? "Triangle" : "Triangles";
                }
            }

            return string.Empty;
        }
    }
}
