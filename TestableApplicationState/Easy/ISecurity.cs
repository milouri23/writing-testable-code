namespace TestableApplicationState.Easy;

public interface ISecurity
{
    void SetUser(string username, bool isAdmin);

    string GetUserName();

    bool IsAdmin();
}