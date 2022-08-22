using System;

namespace TestableObjectConstruction.Shared;

public class Printer : IPrinter
{
    public void SetInkColor(string color)
    {
        throw new NotImplementedException();
    }

    public void SetPageLayout(IPageLayout layout)
    {
        throw new NotImplementedException();
    }

    public void WriteLine(string text)
    {
        throw new NotImplementedException();
    }
}