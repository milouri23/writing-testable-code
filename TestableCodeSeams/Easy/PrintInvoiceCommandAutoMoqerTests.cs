using AutoMoq;
using Moq;
using NUnit.Framework;
using System;
using TestableCodeSeams.Shared;

namespace TestableCodeSeams.Easy;

[TestFixture]
public class PrintInvoiceCommandAutoMoqerTests
{
    private PrintInvoiceCommand _command;
    private AutoMoqer _mocker;
    private Invoice _invoice;

    private const int InvoiceId = 1;
    private const decimal Total = 1.23m;
    private static readonly DateTime Date = new(2001, 2, 3);

    [SetUp]
    public void SetUp()
    {
        _invoice = new() { Id = InvoiceId, Total = Total };

        _mocker = new AutoMoqer();

        _mocker.GetMock<IDatabase>()
            .Setup(p => p.GetInvoice(InvoiceId))
            .Returns(_invoice);

        _mocker.GetMock<IDateTimeWrapper>()
            .Setup(p => p.GetNow())
            .Returns(Date);

        _command = _mocker.Create<PrintInvoiceCommand>();
    }

    [Test]
    [TestCase("Invoice ID: 1")]
    [TestCase("Total: $1,23")]
    [TestCase("Printed: 3/02/2001")]
    public void TestExecuteShouldPrintInvoiceNumber(string line)
    {
        _command.Execute(InvoiceId);

        _mocker.GetMock<IPrinter>()
            .Verify(p => p.WriteLine(line),
                Times.Once);
    }
}