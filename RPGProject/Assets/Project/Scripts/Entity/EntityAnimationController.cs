using UnityEngine;

public class EntityAnimationController : MonoBehaviour
{
    [SerializeField]private Animator _animator;

    protected virtual void Awake()
    {
        if (_animator == null)
        {
            _animator = this.gameObject.GetComponentInDirectChild<Animator>();
        }
    }

    public void SetBool(int hash, bool value)
    {
        _animator.SetBool(hash,value);
    }

    public void SetFloat(int hash, float value)
    {
        _animator.SetFloat(hash, value);
    }

    public void SetInt(int hash, int value)
    {
        _animator.SetInteger(hash, value);
    }

    public void SetTrigger(int hash)
    {
        _animator.SetTrigger(hash);
    }
    
    public float IsPlayAnimation(string tag, int layer = 0)
    {
        if (_animator.GetCurrentAnimatorStateInfo(layer).IsTag(tag))
        {
            return _animator.GetCurrentAnimatorStateInfo(layer).normalizedTime;
        }
        if (_animator.IsInTransition(0))
        {
            if (_animator.GetNextAnimatorStateInfo(layer).IsTag(tag))
            {
                return 0;
            }
        }
        return -1;
    }
}
