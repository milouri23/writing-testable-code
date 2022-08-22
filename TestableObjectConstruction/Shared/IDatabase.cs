namespace TestableObjectConstruction.Shared;

public interface IDatabase
{
    Invoice GetInvoice(int invoiceId);
}