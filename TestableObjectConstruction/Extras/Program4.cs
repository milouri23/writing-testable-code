using Ninject;
using Ninject.Extensions.Conventions;
using TestableObjectConstruction.Easy;

namespace TestableObjectConstruction.Extras;

public class Program4
{
    // Binding by naming convention
    private static void Main(string[] args)
    {
        var container = new StandardKernel();

        container.Bind(p =>
        {
            p.FromThisAssembly()
                .SelectAllClasses()
                .BindDefaultInterface();
        });

        var invoiceId = int.Parse(args[0]);

        var command = container.Get<PrintInvoiceCommand>();

        command.Execute(invoiceId);
    }
}