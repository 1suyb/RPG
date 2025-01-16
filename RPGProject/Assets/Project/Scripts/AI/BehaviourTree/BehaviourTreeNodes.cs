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

public interface BTNode
{
    public abstract NodeState Evaluate();
}

public abstract class CompositeBtNode : BTNode
{
    protected List<BTNode> _nodes = new List<BTNode>();
    protected int _runningNodeIndex;

    protected CompositeBtNode(List<BTNode> nodes)
    {
        this._nodes = nodes;
        _runningNodeIndex = 0;
    }
    
    public abstract NodeState Evaluate();
}

public class ActionBtNode : BTNode
{
    protected Func<NodeState> _action;

    public ActionBtNode(Func<NodeState> action)
    {
        _action = action;
    }

    public virtual NodeState Evaluate()
    {
        return _action();
    }
}


public class SequenceBtNode : CompositeBtNode
{
    public SequenceBtNode(List<BTNode> nodes) : base(nodes)
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

public class SelectorBtNode : CompositeBtNode
{
    public SelectorBtNode(List<BTNode> nodes) : base(nodes)
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

public class RandomSelectBtNode : CompositeBtNode
{
    public RandomSelectBtNode(List<BTNode> nodes) : base(nodes)
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

public class RepeatDecorator : BTNode
{
    protected int _repeatCount;
    protected BTNode BtNode;
    protected int _currentCount;

    public RepeatDecorator(int repeatCount, BTNode btNode)
    {
        _repeatCount = repeatCount;
        BtNode = btNode;
    }
    
    public NodeState Evaluate()
    {
        for (int i = _currentCount; i < _repeatCount; i++)
        {
            NodeState result = BtNode.Evaluate();
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

public class ConditionalDecorator : BTNode
{
    protected Func<bool> _condition;
    protected BTNode BtNode;

    public ConditionalDecorator(Func<bool> condition, BTNode btNode)
    {
        _condition = condition;
        BtNode = btNode;
    } 
    public NodeState Evaluate()
    {
        if (_condition())
        {
            return BtNode.Evaluate();
        }

        return NodeState.Failure;
    }
}

public class ConditionalActionBtNode : BTNode
{
    protected Func<bool> _condition;
    protected Func<NodeState> _action;

    public ConditionalActionBtNode(Func<bool> condition, Func<NodeState> action)
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
