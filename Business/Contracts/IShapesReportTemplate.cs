using System.Collections.Generic;

using Business.Dtos;

namespace Business.Contracts
{
    public interface IShapesReportTemplate
    {
        string GetLanguage();
        string BuildHead(string text);
        string BuildBody(IEnumerable<ShapeReportBodyLine> bodyLines);
        string BuildFoot(ShapeReportFoot foot);
    }
}
