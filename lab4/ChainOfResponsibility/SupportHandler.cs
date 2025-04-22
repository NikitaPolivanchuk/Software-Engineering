namespace ChainOfResponsibility;

public abstract class SupportHandler : ISupportHandler
{
    private ISupportHandler? _next;

    public void SetNext(ISupportHandler handler)
    {
        _next = handler;
    }

    public virtual bool Handle()
    {
        return _next != null && _next.Handle();
    }
}