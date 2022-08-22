﻿namespace TestableWorkWithDependencies.Shared;

public class Login
{
    private readonly User _user;

    public Login(User user)
    {
        _user = user;
    }

    public User GetUser()
    {
        return _user;
    }
}