using System;

using Geometry.Contracts;
using Geometry.Values;

namespace Geometry.Shapes
{
    public class IsoscelesTrapezoid : IGeometricShape
    {
        readonly decimal _leg;
        readonly decimal _minorBase;
        readonly decimal _mayorBase;

        public IsoscelesTrapezoid(decimal leg, decimal minorBase, decimal mayorBase)
        {
            _leg = leg;
            _minorBase = minorBase;
            _mayorBase = mayorBase;
        }

        public decimal CalculateArea()
        {
            var cathetus = (_mayorBase - _minorBase) / 2;

            var radicand = (_leg * _leg) - (cathetus * cathetus);

            return ((_mayorBase + _minorBase) / 2) * (decimal)Math.Sqrt((double)radicand);
        }

        public decimal CalculatePerimeter()
        {
            return _leg * 2 + _minorBase + _mayorBase;
        }

        public ShapeType GetShapeType()
        {
            return ShapeType.IsoscelesTrapezoid;
        }
    }
}
