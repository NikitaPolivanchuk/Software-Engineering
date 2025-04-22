namespace Mediator;

public class CommandCentre : ICommandCenter
{
    private readonly List<Runway> _runways = [];

    public CommandCentre(Runway[] runways)
    {
        _runways.AddRange(runways);
    }

    public void RequestLanding(Aircraft aircraft)
    {
        var freeRunway = _runways.FirstOrDefault(r => r.IsAvailable);
        if (freeRunway != null)
        {
            Console.WriteLine($"Aircraft {aircraft.Name} has landed on runway {freeRunway.Id}");
            freeRunway.AssignAircraft(aircraft);
        }
        else
        {
            Console.WriteLine($"No available runways for aircraft {aircraft.Name} to land");
        }
    }

    public void RequestTakeOff(Aircraft aircraft)
    {
        var runway = _runways.FirstOrDefault(r => r.OccupiedBy == aircraft);
        if (runway != null)
        {
            Console.WriteLine($"Aircraft {aircraft.Name} is taking off from runway {runway.Id}...");
            runway.ClearRunway();
            Console.WriteLine($"Aircraft {aircraft.Name} has taken off.");
        }
        else
        {
            Console.WriteLine($"Aircraft {aircraft.Name} is not assigned to any runway");
        }
    }
}