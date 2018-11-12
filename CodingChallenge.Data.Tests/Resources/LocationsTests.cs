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
        public void CheckValidLanguageTest()
        {
            var keyText = "theKeyTextTest";

            var service = new Locations();

            Assert.Throws<ArgumentException>(() => service.GetTranslation(keyText, (Language)9999));
        }
    }
}
