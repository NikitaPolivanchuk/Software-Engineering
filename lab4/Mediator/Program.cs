namespace Mediator;

internal abstract class Program
{
    public static void Main(string[] args)
    {
        var commandCenter = new CommandCentre([new Runway()]);
        
        var aircraft1 = new Aircraft("A1", commandCenter);
        var aircraft2 = new Aircraft("A2", commandCenter);
        
        aircraft1.RequestLanding();
        aircraft2.RequestLanding();
        
        aircraft1.RequestTakeOff();
        aircraft2.RequestLanding();
    }
}