﻿namespace TestableApplicationState.Hard;

public class Security
{
    private static Security _instance;
    private string _userName;
    private bool _isAdmin;

    public static Security GetInstance()
    {
        if (_instance is null)
            _instance = new Security();

        return _instance;
    }

    private Security()
    { }

    public void SetUser(string userName, bool isAdmin)
    {
        _userName = userName;
        _isAdmin = isAdmin;
    }

    public string GetUserName()
    {
        return _userName;
    }

    public bool IsAdmin()
    {
        return _isAdmin;
    }
}