using System.Collections.Generic;
using System.Linq;
using System.Text;

using Business.Contracts;
using Geometry.Contracts;

namespace CodingChallenge.Data.Classes
{
    public class FormaGeometrica
    {
        #region Idiomas

        public const int Castellano = 1;
        public const int Ingles = 2;

        #endregion

        readonly IGeometricShapesClassifier _classifier;
        readonly IClassificationShapesFormatter _formatter;

        public FormaGeometrica(
            IGeometricShapesClassifier classifier,
            IClassificationShapesFormatter formatter)
        {
            _classifier = classifier;
            _formatter = formatter;
        }

        public string Imprimir(IList<IGeometricShape> shapes, int language)
        {
            var sb = new StringBuilder();

            if (!shapes.Any())
            {
                if (language == Castellano)
                {
                    sb.Append("<h1>Lista vacía de formas!</h1>");
                }
                else
                {
                    sb.Append("<h1>Empty list of shapes!</h1>");
                }

                return sb.ToString();
            }

            if (language == Castellano)
            {
                sb.Append("<h1>Reporte de Formas</h1>");
            }
            else
            {
                sb.Append("<h1>Shapes report</h1>");
            }

            var classifications = _classifier.Classify(shapes);

            var formats = _formatter.Format(classifications, language);

            sb.Append(formats);

            return sb.ToString();
        }
    }
}
