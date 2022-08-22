namespace TestableSingleResponsibility.Shared;

public interface ISecurity
{
    string GetUserName();

    bool IsAdmin();
}