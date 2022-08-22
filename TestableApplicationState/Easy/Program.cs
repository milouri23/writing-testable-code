using Ninject;
using Ninject.Extensions.Conventions;

namespace TestableApplicationState.Easy;

public static class Program
{
    private static void Main(string[] args)
    {
        var invoiceId = int.Parse(args[0]);

        var container = new StandardKernel();

        container.Bind(p =>
        {
            p.FromThisAssembly()
                .SelectAllClasses()
                .BindDefaultInterface();
        });

        container.Bind<ISecurity>()
            .To<Security>()
            .InSingletonScope();

        var command = container.Get<PrintInvoiceCommand>();

        command.Execute(invoiceId);
    }
}