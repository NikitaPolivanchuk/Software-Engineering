using System.Collections;

namespace Composite.Iterators;

public class DepthFirstIterator : IDomIterator
{
    private readonly Stack<LightNode> _stack;
    
    public LightNode Current => _stack.Peek();
    object IEnumerator.Current => Current;

    public DepthFirstIterator(LightNode root)
    {
        _stack = [];
        _stack.Push(root);
    }

    public bool MoveNext()
    {
        if (_stack.Count == 0)
        {
            return false;
        }
        
        var current = _stack.Pop();
        for (var i = current.Children.Count - 1; i >= 0; i--)
        {
            _stack.Push(current.Children[i]);
        }
        return true;
    }

    public void Reset()
    {
        throw new NotSupportedException();
    }

    public void Dispose() { }
}