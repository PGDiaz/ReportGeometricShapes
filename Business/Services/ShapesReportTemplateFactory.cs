using Business.Contracts;
using Business.Templates;
using Resources.Contracts;
using Resources.Values;

namespace Business.Services
{
    public class ShapesReportTemplateFactory : IShapesReportTemplateFactory
    {
        const string FORMAT_HEAD = "<h1>{0}</h1>";

        readonly ILocations _locations;

        public ShapesReportTemplateFactory(ILocations locations)
        {
            _locations = locations;
        }

        public IShapesReportTemplate GetTemplate(Language language)
        {
            return new ShapesReportTemplate(
                language,
                FORMAT_HEAD,
                GetFormatBody(language),
                GetFormatFoot(language));
        }

        string GetFormatBody(Language language)
        {
            var labelArea = _locations.GetTranslation(TranslationKey.LabelArea, language);

            var labelPerimeter = _locations
                .GetTranslation(TranslationKey.LabelPerimeter, language);

            return "{0} {1} | " + labelArea + " {2} | " + labelPerimeter + " {3} <br/>";
        }

        string GetFormatFoot(Language language)
        {
            var labelShapes = _locations
                .GetTranslation(TranslationKey.LabelShapes, language)
                .ToLower();

            var labelPerimeter = _locations
                .GetTranslation(TranslationKey.LabelPerimeter, language);

            var labelArea = _locations.GetTranslation(TranslationKey.LabelArea, language);

            return "TOTAL:<br/>{0} " + labelShapes + " " + labelPerimeter + " {1} " +
                labelArea + " {2}";
        }
    }
}
