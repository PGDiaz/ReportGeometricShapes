using System.Collections.Generic;

using Business.Dtos;
using Resources.Values;

namespace Business.Contracts
{
    public interface IShapesReportTemplate
    {
        Language GetLanguage();
        string BuildHead(string text);
        string BuildBody(IEnumerable<ShapeReportBodyLine> bodyLines);
        string BuildFoot(ShapeReportFoot foot);
    }
}
