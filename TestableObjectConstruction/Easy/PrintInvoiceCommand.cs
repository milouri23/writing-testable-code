using TestableObjectConstruction.Shared;

namespace TestableObjectConstruction.Easy;

public class PrintInvoiceCommand
{
    private readonly IDatabase _database;
    private readonly IInvoiceWriter _writer;

    public PrintInvoiceCommand(
        IDatabase database,
        IInvoiceWriter writer)
    {
        _database = database;
        _writer = writer;
    }

    public void Execute(int invoiceId)
    {
        var invoice = _database.GetInvoice(invoiceId);

        _writer.Write(invoice);
    }
}