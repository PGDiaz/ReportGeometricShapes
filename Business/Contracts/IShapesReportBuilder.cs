using System.Collections.Generic;

using Geometry.Contracts;
using Resources.Values;

namespace Business.Contracts
{
    public interface IShapesReportBuilder
    {
        string Build(IList<IGeometricShape> shapes, Language language);
    }
}
