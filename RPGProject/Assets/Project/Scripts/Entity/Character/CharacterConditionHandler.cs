using System;
using System.Collections;
using UnityEngine;

public class CharacterConditionHandler : MonoBehaviour, ITakeHeal, ITakeDamage
{
    private Condition _hp;
    private Condition _mp;
    private Condition _shield;
    private Condition _hunger;

    [SerializeField] private float _intervalTime = 1f;
    private WaitForSeconds _waitTime;
    private Coroutine _updateCoroutine;

    private CharacterStatHandler _statHandler;
    
    public void Init(CharacterStatHandler statHandler)
    {
        _waitTime = new WaitForSeconds(_intervalTime);
        _hp = new Condition();
        _mp = new Condition();
        _shield = new Condition();
        _hunger = new Condition();
        
        _statHandler = statHandler;
        _updateCoroutine = StartCoroutine(UpdateCondition());
    }
    
    public void OnEnable()
    {
        if (_statHandler != null)
        {
            _statHandler.ChangedStat += SetChangeStat;
        }
    }

    private void OnDestroy()
    {
        if (_updateCoroutine != null)
        {
            StopCoroutine(_updateCoroutine);
        }
    }

    public void OnDisable()
    {
        if (_statHandler != null)
        {
            _statHandler.ChangedStat -= SetChangeStat;
        }
    }
    
    public void SetChangeStat(CharacterStat stat)
    {
        _hp.SetMaxCondition(stat.HP);
        _mp.SetMaxCondition(stat.MP);
        _shield.SetMaxCondition(stat.Shield);
        _hunger.SetMaxCondition(stat.Hunger);
        
        _hp.SetPassiveValue(stat.HpPassiveChangeValue);
        _mp.SetPassiveValue(stat.MpPassiveChangeValue);
        _hunger.SetPassiveValue(stat.HungerPassiveChangeValue);
    }

    public IEnumerator UpdateCondition()
    {
        yield return _waitTime;
        _hp.Update();
        _mp.Update();
        _hunger.Update();
    }

    public void TakeHeal()
    {
        
    }

    public void TakeDamage()
    {
        
    }
}