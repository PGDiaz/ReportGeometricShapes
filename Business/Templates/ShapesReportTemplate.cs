using System.Collections.Generic;
using System.Text;

using Business.Contracts;
using Business.Dtos;

namespace Business.Templates
{
    public class ShapesReportTemplate : IShapesReportTemplate
    {
        const string FORMAT_DECIMAL = "#.##";

        readonly string _language;
        readonly string _formatHead;
        readonly string _formatBody;
        readonly string _formatFoot;

        public ShapesReportTemplate(
            string language,
            string formatHead,
            string formatBody,
            string formatFoot)
        {
            _language = language;
            _formatHead = formatHead;
            _formatBody = formatBody;
            _formatFoot = formatFoot;
        }

        public string GetLanguage()
        {
            return _language;
        }

        public string BuildHead(string text)
        {
            return string.Format(_formatHead, text);
        }

        public string BuildBody(IEnumerable<ShapeReportBodyLine> bodyLines)
        {
            var body = new StringBuilder();

            foreach (var bodyLine in bodyLines)
            {
                body.Append(BuildBodyLine(bodyLine));
            }

            return body.ToString();
        }

        public string BuildFoot(ShapeReportFoot foot)
        {
            return string.Format(
                _formatFoot,
                foot.TotalQuantityShapes,
                foot.TotalShapesPerimeter.ToString(FORMAT_DECIMAL),
                foot.TotalShapesArea.ToString(FORMAT_DECIMAL));
        }

        string BuildBodyLine(ShapeReportBodyLine bodyLine)
        {
            return string.Format(
                _formatBody,
                bodyLine.QuantityShapes,
                bodyLine.ShapeTypeName,
                bodyLine.ShapesArea.ToString(FORMAT_DECIMAL),
                bodyLine.ShapesPerimeter.ToString(FORMAT_DECIMAL));
        }
    }
}
