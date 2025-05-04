using System.Collections;

namespace Composite.Iterators;

public class BreadthFirstIterator : IDomIterator
{
    private readonly Queue<LightNode> _queue;
    
    public LightNode Current => _queue.Peek();
    object IEnumerator.Current => Current;

    public BreadthFirstIterator(LightNode root)
    {
        _queue = [];
        _queue.Enqueue(root);
    }
    
    public bool MoveNext()
    {
        if (_queue.Count == 0)
        {
            return false;
        }
        
        var current = _queue.Dequeue();
        foreach (var child in current.Children)
        {
            _queue.Enqueue(child);
        }
        return true;
    }

    public void Reset()
    {
        throw new NotSupportedException();
    }

    public void Dispose() { }
}