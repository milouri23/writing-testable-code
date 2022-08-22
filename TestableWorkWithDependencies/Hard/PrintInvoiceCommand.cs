using TestableWorkWithDependencies.Shared;

namespace TestableWorkWithDependencies.Hard;

public class PrintInvoiceCommand
{
    private readonly Container _container;

    public PrintInvoiceCommand(Container container)
    {
        _container = container;
    }

    public void Execute(int invoiceId)
    {
        var invoice = _container
            .Get<IDatabase>()
            .GetInvoice(invoiceId);

        _container
            .Get<IInvoiceWriter>()
            .Write(invoice);

        invoice.LastPrintedBy = _container
            .Get<ISession>()
            .GetLogin()
            .GetUser()
            .GetUserName();

        _container
            .Get<IDatabase>()
            .Save();
    }
}