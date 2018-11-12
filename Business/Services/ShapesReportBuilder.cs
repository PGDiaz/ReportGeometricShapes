using System.Collections.Generic;

using Business.Contracts;
using Geometry.Contracts;
using Resources.Values;

namespace Business.Services
{
    public class ShapesReportBuilder : IShapesReportBuilder
    {
        readonly IShapesReportTemplateFactory _factory;
        readonly IGeometricShapesClassifier _classifier;
        readonly IClassificationShapesFormatter _formatter;

        public ShapesReportBuilder(
            IShapesReportTemplateFactory factory,
            IGeometricShapesClassifier classifier,
            IClassificationShapesFormatter formatter)
        {
            _factory = factory;
            _classifier = classifier;
            _formatter = formatter;
        }

        public string Build(IList<IGeometricShape> shapes, Language language)
        {
            var template = _factory.GetTemplate(language);

            var classifiedShapes = _classifier.Classify(shapes);

            return _formatter.Format(template, classifiedShapes).ToString();
        }
    }
}
