﻿using TestableApplicationState.Shared;

namespace TestableApplicationState.Easy;

public class PrintInvoiceCommand
{
    private readonly IDatabase _database;
    private readonly ISecurity _security;
    private readonly IInvoiceWriter _writer;

    public PrintInvoiceCommand(
        IDatabase database,
        ISecurity security,
        IInvoiceWriter writer)
    {
        _database = database;
        _security = security;
        _writer = writer;
    }

    public void Execute(int invoiceId)
    {
        var invoice = _database.GetInvoice(invoiceId);

        if (!_security.IsAdmin())
            throw new UserNotAuthorizedException();

        _writer.Print(invoice);

        invoice.LastPrintedBy = _security.GetUserName();

        _database.Save();
    }
}