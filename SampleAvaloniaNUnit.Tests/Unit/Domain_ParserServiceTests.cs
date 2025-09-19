using NUnit.Framework;
using SampleAvaloniaNUnit.Services;

namespace SampleAvaloniaNUnit.Tests.Unit
{
    /// <summary>
    /// Tests for the ParserService (domain/service).
    /// </summary>
    [TestFixture]
    [Category("Unit")]
    public sealed class Domain_ParserServiceTests
    {
        [Test]
        public void Parse_returns_expected_pairs()
        {
            var svc = new ParserService();
            var dict = svc.Parse("A=1; B=2 ; C = 3");

            Assert.That(dict.Count, Is.EqualTo(3));
            Assert.That(dict["A"], Is.EqualTo("1"));
            Assert.That(dict["B"], Is.EqualTo("2"));
            Assert.That(dict["C"], Is.EqualTo("3"));
        }

        [Test]
        public void Parse_is_robust_for_invalid_pairs()
        {
            var svc = new ParserService();
            var dict = svc.Parse("A=1; B; C=3; =x; D=");

            Assert.That(dict.Count, Is.EqualTo(3));
            Assert.That(dict["A"], Is.EqualTo("1"));
            Assert.That(dict["C"], Is.EqualTo("3"));
            Assert.That(dict["D"], Is.EqualTo(""));  // "D=" -> empty value is fine
        }

        [Test]
        public void Parse_empty_string_returns_empty_dictionary()
        {
            var svc = new ParserService();
            var dict = svc.Parse("   ");

            Assert.That(dict, Is.Empty);
        }
    }
}
