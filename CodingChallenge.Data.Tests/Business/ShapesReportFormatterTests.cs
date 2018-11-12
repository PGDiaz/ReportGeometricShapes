using System.Linq;

using Moq;

using NUnit.Framework;

using Business.Contracts;
using Business.Dtos;
using Business.Services;
using Resources.Contracts;
using Resources.Values;

namespace CodingChallenge.Data.Tests.Business
{
    [TestFixture]
    public class ShapesReportFormatterTests
    {
        [TestCase]
        public void FormattEmptyClassifiedShapesTest()
        {
            var translation = "theTranslation";

            var mockLocations = new Mock<ILocations>();

            mockLocations
                .Setup(s => s.GetTranslation(TranslationKey.EmptyShapes, It.IsAny<Language>()))
                .Returns(translation);

            var service = new ShapesReportFormatter(mockLocations.Object);

            var format = "<h1>{0}</h1>";

            var mockTemplate = new Mock<IShapesReportTemplate>();

            mockTemplate.Setup(s => s.GetLanguage()).Returns(Language.French);

            mockTemplate
                .Setup(s => s.BuildHead(It.IsAny<string>()))
                .Returns((string text) =>
                {
                    if (text == translation)
                    {
                        return string.Format(format, translation);
                    }

                    return format;
                });

            var classifiedShapes = Enumerable.Empty<ClassificationShape>();

            var result = service.Format(mockTemplate.Object, classifiedShapes);

            var expectedResult = string.Format(format, translation);

            Assert.AreEqual(expectedResult, result.ToString());
        }
    }
}
