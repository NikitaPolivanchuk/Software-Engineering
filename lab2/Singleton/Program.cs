namespace Singleton;

internal abstract class Program
{
    public static async Task Main(string[] args)
    {
        var auth1 = Authenticator.GetInstance();
        var auth2 = Authenticator.GetInstance();
        
        Console.WriteLine(ReferenceEquals(auth1, auth2));
        
        var task1 = Task.Run(() => auth1.Authenticate("john_doe"));
        var task2 = Task.Run(() => auth2.Authenticate("jane_doe"));
        
        await Task.WhenAll(task1, task2);
        
        auth1.ShowUsers();
        
        Task.Run(() =>
        {
            var authInThread = Authenticator.GetInstance();
            authInThread.Authenticate("alice_smith");
            authInThread.ShowUsers();
        }).Wait();
        
        auth1.Logout("john_doe");
        
        auth1.ShowUsers();
    }
}