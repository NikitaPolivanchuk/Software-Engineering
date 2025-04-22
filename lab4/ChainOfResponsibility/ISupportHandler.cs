namespace ChainOfResponsibility;

public interface ISupportHandler
{
    void SetNext(ISupportHandler handler);
    bool Handle();
}