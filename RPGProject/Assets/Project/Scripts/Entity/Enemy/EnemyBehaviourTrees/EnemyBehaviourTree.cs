using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviourTree : MonoBehaviour
{
    private BTNode _rootBtNode;
    private bool isInited = true;
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
        ConditionalActionBtNode attackBtNode = new ConditionalActionBtNode(_controller.IsTargetInRange, _controller.Attack);
        ActionBtNode moveBtNode = new ActionBtNode(_controller.Chase);
        ActionBtNode hitBtNode = new ActionBtNode(_controller.Hit);
        ActionBtNode dieBtNode = new ActionBtNode(_controller.Die);
        SelectorBtNode selectorBtNode = new SelectorBtNode(new List<BTNode>() { dieBtNode, hitBtNode, attackBtNode, moveBtNode });
        _rootBtNode = selectorBtNode;
    }
}
