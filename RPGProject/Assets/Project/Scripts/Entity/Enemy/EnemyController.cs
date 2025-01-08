using UnityEngine;

public class EnemyController : EntityController
{
    public void Toward(Transform transform, float speed)
    { 
        Vector3 targetPosition = transform.position;
        Vector3 moveDir = (targetPosition - this.transform.position).normalized;
        
        Move(moveDir, speed);
        LookAt(new Vector2(targetPosition.x,targetPosition.z));
    }
}
