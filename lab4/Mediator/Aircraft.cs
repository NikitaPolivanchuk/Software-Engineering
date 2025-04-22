namespace Mediator;

public class  Aircraft
{
    private readonly ICommandCenter _commandCenter; 
    
    public string Name { get; }
    
    public Aircraft(string name, ICommandCenter commandCenter)
    {
        Name = name;
        _commandCenter = commandCenter;
    }
    
    public void RequestLanding()
    {
        Console.WriteLine($"Aircraft {Name} is requesting to land...");
        _commandCenter.RequestLanding(this);
    }

    public void RequestTakeOff()
    {
        Console.WriteLine($"Aircraft {Name} is requesting to take off...");
        _commandCenter.RequestTakeOff(this);
    }
}