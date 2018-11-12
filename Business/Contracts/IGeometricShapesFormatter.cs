using System.Collections.Generic;
using System.Text;

using Business.Dtos;

namespace Business.Contracts
{
    public interface IClassificationShapesFormatter
    {
        StringBuilder Format(
            IShapesReportTemplate template,
            IEnumerable<ClassificationShape> classifiedShapes);
    }
}
