using System.Collections.Generic;

using Geometry.Contracts;

namespace Business.Contracts
{
    public interface IShapesReportBuilder
    {
        string Build(IList<IGeometricShape> shapes, string language);
    }
}
