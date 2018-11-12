using System;

using NUnit.Framework;

using Resources.Services;
using Resources.Values;

namespace CodingChallenge.Data.Tests.Resources
{
    [TestFixture]
    public class LocationsTests
    {
        [TestCase]
        public void LanguageIsNotValidTest()
        {
            var keyText = "theKeyTextTest";

            var service = new Locations();

            Assert.Throws<ArgumentException>(() =>
                service.GetTranslation(keyText, (Language)9999));
        }

        [TestCase]
        public void KeyTranslationIsNullTest()
        {
            string keyText = null;

            var service = new Locations();

            Assert.Throws<ArgumentNullException>(() =>
                service.GetTranslation(keyText, Language.English));
        }

        [TestCase]
        public void KeyTranslationsIsNotExistsTest()
        {
            var keyText = "theKeyTextTest";

            var service = new Locations();

            var result = service.GetTranslation(keyText, Language.French);

            Assert.AreEqual(keyText, result);
        }

        [TestCase]
        public void TranslationTest()
        {
            var keyText = TranslationKey.LabelPerimeter;

            var service = new Locations();

            var result = service.GetTranslation(keyText, Language.French);

            var expectedResult = "Périmètre";

            Assert.AreEqual(expectedResult, result);
        }
    }
}
