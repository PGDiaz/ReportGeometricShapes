using System.Collections.Generic;

using Business.Contracts;
using Geometry.Contracts;

namespace CodingChallenge.Data.Classes
{
    public class FormaGeometrica
    {
        readonly IShapesReportBuilder _builder;

        public FormaGeometrica(IShapesReportBuilder builder)
        {
            _builder = builder;
        }

        public string Imprimir(IList<IGeometricShape> shapes, string language)
        {
            return _builder.Build(shapes, language);
        }
    }
}
