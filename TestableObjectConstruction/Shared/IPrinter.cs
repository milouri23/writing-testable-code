namespace TestableObjectConstruction.Shared;

public interface IPrinter
{
    void SetPageLayout(IPageLayout layout);

    void SetInkColor(string color);

    void WriteLine(string text);
}