using System;

namespace TestableObjectConstruction.Shared;

public class Database : IDatabase
{
    public Invoice GetInvoice(int invoiceId)
    {
        throw new NotImplementedException();
    }
}