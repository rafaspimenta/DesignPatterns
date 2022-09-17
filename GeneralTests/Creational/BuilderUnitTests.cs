using Builder;
using NUnit.Framework;

namespace GeneralTests.Builder
{
    public class BuilderUnitTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void BuilderParameter()
        {
            var emailService = new EMailService();

            emailService.SendEmail(b =>
            b.From("rafael@")
            .To("fernanda@")
            .Subject("Test")
            .Body("email de test"));

            Assert.True(true);
        }

        [Test]
        public void FluentBuilder()
        {
            var rootElement = new HtmlBuilder("ul")
                .AddChild("li", "hello")
                .AddChild("li", "world")
                .Build();

            Assert.That(true);
        }

        [Test]
        public void LazyFunctionalBuilder()
        {
            var person = new PersonBuilder()
                .Called("Dmitri")
                .Build();

            Assert.That(person.Name, Is.EqualTo("Dmitri"));
        }
    }
}