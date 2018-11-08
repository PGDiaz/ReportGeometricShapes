using System.Collections.Generic;

using Business.Dtos;

namespace Business.Contracts
{
    public interface IClassificationShapesFormatter
    {
        string Format(IEnumerable<ClassificationShape> classifications, int language);
    }
}
