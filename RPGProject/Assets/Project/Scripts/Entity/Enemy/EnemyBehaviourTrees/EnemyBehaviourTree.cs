using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviourTree : MonoBehaviour
{
    private BTNode _rootBtNode;
    private bool isInited = true;
    [SerializeField] protected Transform _target;
    [SerializeField] protected float _attackRange;
    [SerializeField] protected EnemyController _controller;

    public void Update()
    {
        if (isInited)
        {
            _rootBtNode.Evaluate();
        }
    }

    public void Awake()
    {
        ConditionalActionBtNode attackBtNode = new ConditionalActionBtNode(() =>
            {
                return _attackRange>this.transform.Distance(_target);
            }, () =>
            {
                Debug.Log($"Attack player{this.transform.Distance(_target)}");
                return NodeState.Success;
            });
        ActionBtNode moveBtNode = new ActionBtNode(() =>
        {
            _controller.Toward(_target,1f);
            return NodeState.Success;
        });
        SelectorBtNode selectorBtNode = new SelectorBtNode(new List<BTNode>() { attackBtNode, moveBtNode });
        _rootBtNode = selectorBtNode;
    }
}
