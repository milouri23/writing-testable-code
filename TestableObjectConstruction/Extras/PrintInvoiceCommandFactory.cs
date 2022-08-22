using TestableObjectConstruction.Easy;
using TestableObjectConstruction.Shared;

namespace TestableObjectConstruction.Extras;

public class PrintInvoiceCommandFactory
{
    public PrintInvoiceCommand Create()
    {
        var command = new PrintInvoiceCommand(
            new Database(),
            new InvoiceWriter(
                new Printer(),
                new PageLayout()));

        return command;
    }
}