using AutoMoq;
using Moq;
using NUnit.Framework;
using TestableSingleResponsibility.Shared;

namespace TestableSingleResponsibility.Hard;

[TestFixture]
public class PrintOrEmailInvoiceCommandTests
{
    private PrintOrEmailInvoiceCommand _command;
    private AutoMoqer _mocker;
    private Invoice _invoice;

    public const int InvoiceId = 1;
    public const string EmailAddress = "email@test.com";
    public const string Username = "mrenze";

    [SetUp]
    public void SetUp()
    {
        _invoice = new Invoice();

        _mocker = new AutoMoqer();

        _mocker.GetMock<IDatabase>()
            .Setup(p => p.GetInvoice(InvoiceId))
            .Returns(_invoice);

        _mocker.GetMock<ISecurity>()
            .Setup(p => p.IsAdmin())
            .Returns(true);

        _mocker.GetMock<ISecurity>()
            .Setup(p => p.GetUserName())
            .Returns(Username);

        _command = _mocker
            .Create<PrintOrEmailInvoiceCommand>();
    }

    [Test]
    public void TestExecuteForEmailingInvoiceWithNoEmailAddressShouldThrowException()
    {
        _invoice.EmailAddress = string.Empty;

        Assert.That(() => _command.Execute(InvoiceId, true),
            Throws.TypeOf<EmailAddressIsBlankException>());
    }

    [Test]
    public void TestExecuteShouldEmailInvoiceIfEmailing()
    {
        _invoice.EmailAddress = EmailAddress;

        _command.Execute(InvoiceId, true);

        _mocker.GetMock<IInvoiceEmailer>()
            .Verify(p => p.Email(_invoice),
                Times.Once);
    }

    [Test]
    public void TestExecuteShouldThrowExceptionIfPrintingAndUserIsNotAdmin()
    {
        _mocker.GetMock<ISecurity>()
            .Setup(p => p.IsAdmin())
            .Returns(false);

        Assert.That(() => _command.Execute(InvoiceId, false),
            Throws.TypeOf<UserNotAuthorizedException>());
    }

    [Test]
    public void TestExecuteShouldPrintInvoiceIfPrinting()
    {
        _command.Execute(InvoiceId, false);

        _mocker.GetMock<IInvoiceWriter>()
            .Verify(p => p.Print(_invoice),
                Times.Once);
    }

    [Test]
    public void TestExecuteShouldSetLastPrintedByToCurrentUserIfPrinting()
    {
        _command.Execute(InvoiceId, false);

        Assert.That(_invoice.LastPrintedBy,
            Is.EqualTo("mrenze"));
    }

    [Test]
    public void TestExecuteShouldSaveChangesToDatabaseIfPrinting()
    {
        _command.Execute(InvoiceId, false);

        _mocker.GetMock<IDatabase>()
            .Verify(p => p.Save(),
                Times.Once);
    }
}