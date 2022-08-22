using TestableObjectConstruction.Shared;

namespace TestableObjectConstruction.Hard;

public class PrintInvoiceCommand
{
    private readonly IDatabase _database;
    private readonly IPrinter _printer;

    public PrintInvoiceCommand(
        IDatabase database,
        IPrinter printer)
    {
        _database = database;
        _printer = printer;
    }

    public void Execute(int invoiceId)
    {
        var invoice = _database.GetInvoice(invoiceId);

        var writer = new InvoiceWriter(_printer, invoice);

        writer.Write();
    }
}