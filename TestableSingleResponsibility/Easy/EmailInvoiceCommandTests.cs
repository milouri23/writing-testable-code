using AutoMoq;
using Moq;
using NUnit.Framework;
using TestableSingleResponsibility.Shared;

namespace TestableSingleResponsibility.Easy;

[TestFixture]
public class EmailInvoiceCommandTests
{
    private EmailInvoiceCommand _command;
    private AutoMoqer _mocker;
    private Invoice _invoice;

    public const int InvoiceId = 1;
    public const string EmailAddress = "email@test.com";

    [SetUp]
    public void SetUp()
    {
        _invoice = new Invoice()
        {
            EmailAddress = EmailAddress
        };

        _mocker = new AutoMoqer();

        _mocker.GetMock<IDatabase>()
            .Setup(p => p.GetInvoice(InvoiceId))
            .Returns(_invoice);

        _command = _mocker.Create<EmailInvoiceCommand>();
    }

    [Test]
    public void TestExecuteForInvoiceWithNoEmailAddressShouldThrowException()
    {
        _invoice.EmailAddress = string.Empty;

        Assert.That(() => _command.Execute(InvoiceId),
            Throws.TypeOf<EmailAddressIsBlankException>());
    }

    [Test]
    public void TestExecuteShouldEmailInvoice()
    {
        _command.Execute(InvoiceId);

        _mocker.GetMock<IInvoiceEmailer>()
            .Verify(p => p.Email(_invoice),
                Times.Once);
    }
}