namespace Mediator;

public class Runway
{
    public Guid Id { get; } = Guid.NewGuid();
    public Aircraft? OccupiedBy { get; private set; }
    
    public bool IsAvailable => OccupiedBy == null;
    
    public void AssignAircraft(Aircraft aircraft)
    {
        OccupiedBy = aircraft;
        HighLightRed();
    }

    public void ClearRunway()
    {
        OccupiedBy = null;
        HighLightGreen();
    }

    public void HighLightRed()
    {
        Console.WriteLine($"Runway {Id} is busy");
    }

    public void HighLightGreen()
    {
        Console.WriteLine($"Runway {Id} is free");
    }
}