using System;

namespace TestableWorkWithDependencies.Shared;

public class Container
{
    public T Get<T>()
    {
        throw new NotImplementedException();
    }
}