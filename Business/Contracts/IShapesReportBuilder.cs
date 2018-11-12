using System.Collections.Generic;

using Geometry.Contracts;
using Resources.Values;

namespace Business.Contracts
{
    public interface IShapesReportBuilder
    {
        string Build(IEnumerable<IGeometricShape> shapes, Language language);
    }
}
