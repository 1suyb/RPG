using System.Collections.Generic;
using UnityEngine;

public class CharacterTargetDetect : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private int _maxCount = 10;
    
    private List<IDamageable> _targetList = new List<IDamageable>();
    private List<Transform> _transformList = new List<Transform>();
    private void OnTriggerEnter(Collider other)
    {
        if(1<<other.gameObject.layer== _character.TargetLayer)
        {
            if(_targetList.Count >= _maxCount)
                return;
            IDamageable obj = other.GetComponent<IDamageable>();
            if(obj == null)
                return;
            _targetList.Add(obj);
            _transformList.Add(other.transform);
            
            obj.OnDie+= () => Remove(other.transform);
            SetTarget();
        }
    }

    private void Remove(Transform other)
    {
        IDamageable obj = other.GetComponent<IDamageable>();
        if(obj == null)
            return;
        if(_targetList.Contains(obj))
            _targetList.Remove(obj);
        if(_transformList.Contains(other))
            _transformList.Remove(other);
        SetTarget();
    }

    private void SetTarget()
    {
        if(_targetList.Count == 0)
        {
            _character.SetTarget(null);
            return;
        }
        Transform closet = this.transform.Closest(_transformList);
        _character.SetTarget(closet);
    }

    private void OnTriggerExit(Collider other)
    {
        if(1<<other.gameObject.layer == _character.TargetLayer)
        {
            Remove(other.transform);
            
        }
    }
}
