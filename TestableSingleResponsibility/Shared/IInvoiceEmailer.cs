namespace TestableSingleResponsibility.Shared;

public interface IInvoiceEmailer
{
    void Email(Invoice invoice);
}