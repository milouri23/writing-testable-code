namespace TestableCodeConsole;

public class Calculator
{
    public decimal GetTotal(decimal parts, decimal service, decimal discount)
    {
        return parts + service - discount;
    }
}