using System;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBuffReceiver : MonoBehaviour
{
    private List<Buff> _buffs = new List<Buff>();
    [SerializeField]private Character _character;
    private StatHandler _statHandler => _character.StatHandler;

    public void Init(Character character)
    {
        _character = character;
    }

    public void AddBuff(BuffInfo buff)
    {
        Buff newBuff = new Buff(buff, _statHandler.CurrentStat);
        _statHandler.AddStat(newBuff.Stat);
        _buffs.Add(newBuff);
    }
    
    public void RemoveBuff(BuffInfo buff)
    {

    }

    private void Update()
    {
        for (int i = 0; i < _buffs.Count; i++)
        {
            _buffs[i].UpdateBuff(Time.deltaTime,_character);
            if(_buffs[i].IsDone)
            {
                _statHandler.SubtractStat(_buffs[i].Stat);
                _buffs.RemoveAt(i);
            }
        }
    }
}

// StatHandler에서 CurrentStat을 참조해서 Buff의 Stat 증감을 계산
// Buff의 스넷 증감을 StatHandler에 적용, HP, MP, SP, 등의 컨디션 적용
// Buff의 남은시간을 체크해서 정렬
   // Buff의 남은시간이 길면 앞에, 짧으면 뒤에


