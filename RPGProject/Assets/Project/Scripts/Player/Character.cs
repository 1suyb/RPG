using System;
using UnityEngine;

public class Character : MonoBehaviour
{

    [field:SerializeField] public CharacterStateMachine StateMachine { get; private set; }

    public void Start()
    {
        StateMachine.Init(this);
    }
}
