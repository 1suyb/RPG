using UnityEngine;

public class EnemyController : EntityController
{
    [SerializeField] protected EnemyAnimationController _animationController;
    public void Toward(Transform transform, float speed)
    { 
        Vector3 targetPosition = transform.position;
        Vector3 moveDir = (targetPosition - this.transform.position).normalized;
        
        Move(moveDir, speed);
        LookAt(new Vector2(targetPosition.x,targetPosition.z));
    }

    private bool isAttack;
    private bool isStuned;
    private bool isHited;
    
    
    public NodeState Attack()
    {
        
        _animationController.Attack(0);
        return NodeState.Success;
    }
    

    public void Chase()
    {
        
    }

    public void Stun()
    {
        
    }

    public void Hit()
    {
        
    }
    
    
    
}
