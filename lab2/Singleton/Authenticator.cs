namespace Singleton;

public sealed class Authenticator
{
    #region Singleton

    private static Authenticator? _instance;
    private static readonly object Lock = new();

    private Authenticator() {}

    public static Authenticator GetInstance()
    {
        if (_instance == null)
        {
            lock (Lock)
            {
                _instance ??= new Authenticator();
            }
        }
        return _instance;
    }
    
    #endregion Singleton

    private readonly List<string> _users = [];
    
    public void Authenticate(string username)
    {
        if (!_users.Contains(username))
        {
            _users.Add(username);
            Console.WriteLine($"User {username} authenticated and added to the list.");
        }
        else
        {
            Console.WriteLine($"User {username} is already in the list.");
        }
    }
    
    public void ShowUsers()
    {
        if (_users.Count == 0)
        {
            Console.WriteLine("No users are authenticated.");
        }
        else
        {
            Console.WriteLine("Authenticated users:");
            foreach (var user in _users)
            {
                Console.WriteLine(user);
            }
        }
    }
    
    public void Logout(string username)
    {
        Console.WriteLine(_users.Remove(username)
            ? $"User {username} logged out and removed from the list."
            : $"User {username} not found.");
    }
}