namespace TestableWorkWithDependencies.Shared;

public interface IInvoiceWriter
{
    void Write(Invoice invoice);
}