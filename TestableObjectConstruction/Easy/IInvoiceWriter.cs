using TestableObjectConstruction.Shared;

namespace TestableObjectConstruction.Easy;

public interface IInvoiceWriter
{
    public void Write(Invoice invoice);
}