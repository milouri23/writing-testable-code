namespace TestableObjectConstruction.Extras
{
    public class Program2
    {
        public static void Main(string[] args)
        {
            var invoiceId = int.Parse(args[0]);

            var factory = new PrintInvoiceCommandFactory();

            var command = factory.Create();

            command.Execute(invoiceId);
        }
    }
}