using Builder;

namespace GeneralTests.Builder
{
    public class Builder
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void BuilderParameter()
        {
            var emailService = new EMailService();
            static void builder(EMailService.EmailBuilder b) =>
            b.From("rafael@")
            .To("fernanda@")
            .Subject("Test")
            .Body("email de test");

            emailService.SendEmail(builder);

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
    }
}