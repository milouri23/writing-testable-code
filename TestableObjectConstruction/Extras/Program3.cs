using Ninject;
using TestableObjectConstruction.Easy;
using TestableObjectConstruction.Shared;

namespace TestableObjectConstruction.Extras;

public class Program3
{
    private static void Main(string[] args)
    {
        var container = new StandardKernel();

        container.Bind<IDatabase>()
            .To<Database>();

        container.Bind<IInvoiceWriter>()
            .To<InvoiceWriter>();

        container.Bind<IPrinter>()
            .To<Printer>();

        container.Bind<IPageLayout>()
            .To<PageLayout>();

        var invoiceId = int.Parse(args[0]);

        var command = container.Get<PrintInvoiceCommand>();

        command.Execute(invoiceId);
    }
}