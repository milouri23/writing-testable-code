using TestableObjectConstruction.Shared;

namespace TestableObjectConstruction.Easy
{
    public class InvoiceWriter : IInvoiceWriter
    {
        private readonly IPrinter _printer;
        private readonly IPageLayout _layout;

        public InvoiceWriter(
            IPrinter printer,
            IPageLayout layout)
        {
            _printer = printer;
            _layout = layout;
        }

        public void Write(Invoice invoice)
        {
            _printer.SetPageLayout(_layout);

            if (invoice.IsOverdue)
                _printer.SetInkColor("Red");

            _printer.WriteLine("Invoice ID: " + invoice.Id);

            // Remaining print statements would go here
        }
    }
}