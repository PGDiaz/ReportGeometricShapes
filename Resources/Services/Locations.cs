using System;
using System.Collections.Generic;

using Resources.Contracts;
using Resources.Values;

namespace Resources.Services
{
    public class Locations : ILocations
    {
        readonly IDictionary<string, string> _resource;
        readonly IDictionary<string, string> _esResource;

        public Locations()
        {
            _resource = InitializeResource();
            _esResource = InitializeEsResource();
        }

        public string GetTranslation(string keyText, Language language)
        {
            if (string.IsNullOrEmpty(keyText))
            {
                throw new ArgumentNullException("keyText", "The parameter must not be null.");
            }

            switch (language)
            {
                case Language.Spanish:
                    return TryGetTranslation(_esResource, keyText);
                case Language.English:
                    return TryGetTranslation(_resource, keyText);
                default:
                    throw new ArgumentException("Must provide a valid language.", "language");
            }
        }

        string TryGetTranslation(IDictionary<string, string> resource, string keyText)
        {
            if (resource.ContainsKey(keyText))
            {
                return resource[keyText];
            }

            return keyText;
        }

        IDictionary<string, string> InitializeResource()
        {
            return new Dictionary<string, string>
            {
                { TranslationKey.EmptyShapes, "Empty list of shapes!" },
                { TranslationKey.HeadReportShapes, "Shapes report" },
                { TranslationKey.LabelArea, "Area" },
                { TranslationKey.LabelPerimeter, "Perimeter" },
                { TranslationKey.LabelShapes, "Shapes"},
                { TranslationKey.LabelSquare, "Square" },
                { TranslationKey.LabelSquares, "Squares" },
                { TranslationKey.LabelCircle, "Circle" },
                { TranslationKey.LabelCircles, "Circles" },
                { TranslationKey.LabelTriangle, "Triangle" },
                { TranslationKey.LabelTriangles, "Triangles" },
            };
        }

        IDictionary<string, string> InitializeEsResource()
        {
            return new Dictionary<string, string>
            {
                { TranslationKey.EmptyShapes, "Lista vacía de formas!" },
                { TranslationKey.HeadReportShapes, "Reporte de Formas" },
                { TranslationKey.LabelArea, "Área" },
                { TranslationKey.LabelPerimeter, "Perímetro" },
                { TranslationKey.LabelShapes, "Formas"},
                { TranslationKey.LabelSquare, "Cuadrado" },
                { TranslationKey.LabelSquares, "Cuadrados" },
                { TranslationKey.LabelCircle, "Círculo" },
                { TranslationKey.LabelCircles, "Círculos" },
                { TranslationKey.LabelTriangle, "Triángulo" },
                { TranslationKey.LabelTriangles, "Triángulos" },
            };
        }
    }
}
