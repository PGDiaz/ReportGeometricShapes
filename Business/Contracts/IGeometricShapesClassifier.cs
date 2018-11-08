using System.Collections.Generic;

using Business.Dtos;
using Geometry.Contracts;

namespace Business.Contracts
{
    public interface IGeometricShapesClassifier
    {
        IEnumerable<ClassificationShape> Classify(IEnumerable<IGeometricShape> shapes);
    }
}
