namespace TestableSingleResponsibility.Shared;

public interface IInvoiceWriter
{
    void Print(Invoice invoice);
}