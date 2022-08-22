using TestableObjectConstruction.Easy;
using TestableObjectConstruction.Shared;

namespace TestableObjectConstruction.Extras;

public static class Program1
{
    public static void Main(string[] args)
    {
        var invoiceId = int.Parse(args[0]);

        // Poor man's dependency injection
        var command = new PrintInvoiceCommand(
            new Database(),
            new InvoiceWriter(
                new Printer(),
                new PageLayout()));

        command.Execute(invoiceId);
    }
}