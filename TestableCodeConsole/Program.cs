using System;

namespace TestableCodeConsole;

public static class Program
{
    public static void Main(string[] args)
    {
        var parts = decimal.Parse(args[0]);
        var service = decimal.Parse(args[1]);
        var discount = decimal.Parse(args[2]);

        Calculator calculator = new();
        var total = calculator.GetTotal(parts, service, discount);

        Console.WriteLine("Total Price: $" + total);
    }
}