﻿namespace TestableWorkWithDependencies.Shared;

public class User
{
    private readonly string _userName;

    public User(string userName)
    {
        _userName = userName;
    }

    public string GetUserName()
    {
        return _userName;
    }
}