using AutoMoq;
using Moq;
using NUnit.Framework;
using TestableApplicationState.Shared;

namespace TestableApplicationState.Easy;

[TestFixture]
public class PrintInvoiceCommandTests
{
    private PrintInvoiceCommand _command;
    private AutoMoqer _mocker;
    private Invoice _invoice;

    private const int InvoiceId = 1;
    private const string UserName = "mrenze";

    [SetUp]
    public void Setup()
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
            .Returns(UserName);

        _command = _mocker.Create<PrintInvoiceCommand>();
    }

    [Test]
    public void TestExecuteShouldThrowExceptionIfUserIsNotAdmin()
    {
        _mocker.GetMock<ISecurity>()
            .Setup(p => p.IsAdmin())
            .Returns(false);

        Assert.That(() => _command.Execute(InvoiceId),
            Throws.TypeOf<UserNotAuthorizedException>());
    }

    [Test]
    public void TestExecuteShouldPrintInvoice()
    {
        _command.Execute(InvoiceId);

        _mocker.GetMock<IInvoiceWriter>()
            .Verify(p => p.Print(_invoice),
                Times.Once);
    }

    [Test]
    public void TestExecuteShouldSetLastPrintedByToCurrentUser()
    {
        _command.Execute(InvoiceId);

        Assert.That(_invoice.LastPrintedBy,
            Is.EqualTo(UserName));
    }

    [Test]
    public void TestExecuteShouldSaveChangesToDatabase()
    {
        _command.Execute(InvoiceId);

        _mocker.GetMock<IDatabase>()
            .Verify(p => p.Save(),
                Times.Once);
    }
}