using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviourTree : MonoBehaviour
{
    private Node _rootNode;
    private bool isInited = true;
    [SerializeField] protected Transform _target;
    [SerializeField] protected float _attackRange;
    [SerializeField] protected EnemyController _controller;

    public void Update()
    {
        if (isInited)
        {
            _rootNode.Evaluate();
        }
    }

    public void Awake()
    {
        ConditionalActionNode attackNode = new ConditionalActionNode(() =>
            {
                return _attackRange>this.transform.Distance(_target);
            }, () =>
            {
                Debug.Log($"Attack player{this.transform.Distance(_target)}");
                return NodeState.Success;
            });
        ActionNode moveNode = new ActionNode(() =>
        {
            _controller.Toward(_target,1f);
            return NodeState.Success;
        });
        SelectorNode selectorNode = new SelectorNode(new List<Node>() { attackNode, moveNode });
        _rootNode = selectorNode;
    }
}
