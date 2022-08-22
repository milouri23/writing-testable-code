using TestableCodeSeams.Shared;

namespace TestableCodeSeams.Easy;

public interface IDatabase
{
    Invoice GetInvoice(int invoiceId);
}