using System;

namespace TestableCodeSeams.Easy;

public class DateTimeWrapper : IDateTimeWrapper
{
    public DateTime GetNow()
    {
        return DateTime.Now;
    }
}