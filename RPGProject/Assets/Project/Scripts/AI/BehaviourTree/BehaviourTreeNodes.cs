using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using Random = UnityEngine.Random;

public enum NodeState
{
    Success,
    Failure,
    Running
}

public interface Node
{
    public abstract NodeState Evaluate();
}

public abstract class CompositeNode : Node
{
    protected List<Node> _nodes = new List<Node>();
    protected int _runningNodeIndex;

    protected CompositeNode(List<Node> nodes)
    {
        this._nodes = nodes;
        _runningNodeIndex = 0;
    }
    
    public abstract NodeState Evaluate();
}

public class ActionNode : Node
{
    protected Func<NodeState> _action;

    public ActionNode(Func<NodeState> action)
    {
        _action = action;
    }

    public virtual NodeState Evaluate()
    {
        return _action();
    }
}


public class SequenceNode : CompositeNode
{
    public SequenceNode(List<Node> nodes) : base(nodes)
    {
    }

    public override NodeState Evaluate()
    {
        for (int i = _runningNodeIndex; i < _nodes.Count; i++)
        {
            if (_nodes[i].Evaluate() == NodeState.Failure)
            {
                _runningNodeIndex = 0;
                return NodeState.Failure;
            }

            if (_nodes[i].Evaluate() == NodeState.Running)
            {
                _runningNodeIndex = i;
                return NodeState.Running;
            }
        }

        _runningNodeIndex = 0;
        return NodeState.Success;
    }
}

public class SelectorNode : CompositeNode
{
    public SelectorNode(List<Node> nodes) : base(nodes)
    {
    }

    public override NodeState Evaluate()
    {
        for (int i = _runningNodeIndex; i < _nodes.Count; i++)
        {
            if (_nodes[i].Evaluate() == NodeState.Running)
            {
                _runningNodeIndex = i;
                return NodeState.Running;
            }

            if (_nodes[i].Evaluate() == NodeState.Success)
            {
                _runningNodeIndex = 0;
                return NodeState.Success;
            }
        }
        _runningNodeIndex = 0;
        return NodeState.Failure;
    }
}

public class RandomSelectNode : CompositeNode
{
    public RandomSelectNode(List<Node> nodes) : base(nodes)
    {
    }

    public override NodeState Evaluate()
    {
        if (_runningNodeIndex != 0)
        {
            NodeState result = _nodes[_runningNodeIndex].Evaluate();
            if (result == NodeState.Running)
            {
                return NodeState.Running;
            }
            else
            {
                _runningNodeIndex = 0;
                return result;
            }
        }
        int index = Random.Range(0, _nodes.Count);
        NodeState randomResult = _nodes[index].Evaluate();
        if (randomResult == NodeState.Running)
        {
            _runningNodeIndex = index;
            return NodeState.Running;
        }
        else
        {
            _runningNodeIndex = 0;
            return randomResult;
        }
        
    }
}

public class RepeatDecorator : Node
{
    protected int _repeatCount;
    protected Node _node;
    protected int _currentCount;

    public RepeatDecorator(int repeatCount, Node node)
    {
        _repeatCount = repeatCount;
        _node = node;
    }
    
    public NodeState Evaluate()
    {
        for (int i = _currentCount; i < _repeatCount; i++)
        {
            NodeState result = _node.Evaluate();
            if (result == NodeState.Running)
            {
                _currentCount = i;
                return result;
            }
        }

        _currentCount = 0;
        return NodeState.Success;
    }
}

public class ConditionalDecorator : Node
{
    protected Func<bool> _condition;
    protected Node _node;

    public ConditionalDecorator(Func<bool> condition, Node node)
    {
        _condition = condition;
        _node = node;
    } 
    public NodeState Evaluate()
    {
        if (_condition())
        {
            return _node.Evaluate();
        }

        return NodeState.Failure;
    }
}

public class ConditionalActionNode : Node
{
    protected Func<bool> _condition;
    protected Func<NodeState> _action;

    public ConditionalActionNode(Func<bool> condition, Func<NodeState> action)
    {
        _condition = condition;
        _action = action;
    }
    public NodeState Evaluate()
    {
        if (_condition())
        {
            return _action();
        }

        return NodeState.Failure;
    }
}
