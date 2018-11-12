using System.Collections.Generic;
using System.Linq;
using System.Text;

using Business.Contracts;
using Business.Dtos;
using Business.Mappers;
using Geometry.Values;
using Resources.Contracts;
using Resources.Values;

namespace Business.Services
{
    public class ShapesReportFormatter : IClassificationShapesFormatter
    {
        readonly ILocations _locations;

        public ShapesReportFormatter(ILocations locations)
        {
            _locations = locations;
        }

        public StringBuilder Format(
            IShapesReportTemplate template,
            IEnumerable<ClassificationShape> classifiedShapes)
        {
            var headText = string.Empty;

            if (!classifiedShapes.Any())
            {
                headText = _locations
                    .GetTranslation(TranslationKey.EmptyShapes, template.GetLanguage());

                return new StringBuilder(template.BuildHead(headText));
            }

            headText = _locations
                .GetTranslation(TranslationKey.HeadReportShapes, template.GetLanguage());

            var report = new StringBuilder(template.BuildHead(headText));

            var shapesTranslations = GetShapesTranslations(
                classifiedShapes,
                template.GetLanguage());

            var body = classifiedShapes.ConvertToShapeReportBody(shapesTranslations);

            report.Append(template.BuildBody(body));

            var foot = classifiedShapes.ConvertToShapeReportFoot();

            report.Append(template.BuildFoot(foot));

            return report;
        }

        IDictionary<ShapeType, string> GetShapesTranslations(
            IEnumerable<ClassificationShape> classifiedShapes,
            Language language)
        {
            return classifiedShapes.ToDictionary(
                classifiedShape => classifiedShape.ShapeType,
                classifiedShape =>
                {
                    switch (classifiedShape.ShapeType)
                    {
                        case ShapeType.Square:
                            return classifiedShape.Quantity == 1 ?
                                _locations.GetTranslation(TranslationKey.LabelSquare, language) :
                                _locations.GetTranslation(TranslationKey.LabelSquares, language);
                        case ShapeType.Circle:
                            return classifiedShape.Quantity == 1 ?
                                _locations.GetTranslation(TranslationKey.LabelCircle, language) :
                                _locations.GetTranslation(TranslationKey.LabelCircles, language);
                        case ShapeType.EquilateralTriangle:
                            return classifiedShape.Quantity == 1 ?
                                _locations.GetTranslation(TranslationKey.LabelTriangle, language) :
                                _locations.GetTranslation(TranslationKey.LabelTriangles, language);
                        default:
                            return string.Empty;
                    }
                });
        }
    }
}
