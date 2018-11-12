using System;

using Resources.Contracts;
using Resources.Values;

namespace Resources.Services
{
    public class Locations : ILocations
    {
        public string GetTranslation(string keyText, string language)
        {
            if (string.IsNullOrEmpty(keyText))
            {
                throw new ArgumentNullException("keyText", "The parameter must not be null.");
            }

            if (string.IsNullOrEmpty(language))
            {
                throw new ArgumentNullException("language", "Must provide a language.");
            }

            if (keyText == TranslationKey.EmptyShapes)
            {
                if (language == Language.Spanish)
                {
                    return "Lista vacía de formas!";
                }

                return "Empty list of shapes!";
            }

            if (keyText == TranslationKey.HeadReportShapes)
            {
                if (language == Language.Spanish)
                {
                    return "Reporte de Formas";
                }

                return "Shapes report";
            }

            if (keyText == TranslationKey.LabelArea)
            {
                if (language == Language.Spanish)
                {
                    return "Área";
                }

                return "Area";
            }

            if (keyText == TranslationKey.LabelPerimeter)
            {
                if (language == Language.Spanish)
                {
                    return "Perímetro";
                }

                return "Perimeter";
            }

            if (keyText == TranslationKey.LabelShapes)
            {
                if (language == Language.Spanish)
                {
                    return "Formas";
                }

                return "Shapes";
            }

            if (keyText == TranslationKey.LabelSquare)
            {
                if (language == Language.Spanish)
                {
                    return "Cuadrado";
                }

                return "Square";
            }

            if (keyText == TranslationKey.LabelSquares)
            {
                if (language == Language.Spanish)
                {
                    return "Cuadrados";
                }

                return "Squares";
            }

            if (keyText == TranslationKey.LabelCircle)
            {
                if (language == Language.Spanish)
                {
                    return "Círculo";
                }

                return "Circle";
            }

            if (keyText == TranslationKey.LabelCircles)
            {
                if (language == Language.Spanish)
                {
                    return "Círculos";
                }

                return "Circles";
            }

            if (keyText == TranslationKey.LabelTriangle)
            {
                if (language == Language.Spanish)
                {
                    return "Triángulo";
                }

                return "Triangle";
            }

            if (keyText == TranslationKey.LabelTriangles)
            {
                if (language == Language.Spanish)
                {
                    return "Triángulos";
                }

                return "Triangles";
            }

            return string.Empty;
        }
    }
}
