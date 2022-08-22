namespace TestableApplicationState.Easy;

public class Security : ISecurity
{
    private string _userName;
    private bool _isAdmin;

    public void SetUser(string username, bool isAdmin)
    {
        _userName = username;
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