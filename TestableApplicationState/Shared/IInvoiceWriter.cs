namespace TestableApplicationState.Shared;

public interface IInvoiceWriter
{
    void Print(Invoice invoice);
}