using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/InputEventListenerSO")]
public class InputEventListenerSO : ScriptableObject
{
    [field:SerializeField] public Vector2 LookDir { get; private set; }
    [field:SerializeField] public Vector3 MoveDir { get; private set; }
    public void SetLookDir(Vector2 value)
    {
        LookDir = value;
    }
    public void SetMoveDir(Vector2 value)
    {
        Vector3 newDir = new Vector3(value.x,0,value.y).normalized;
        if (MoveDir != newDir)
        {
            MoveDir = newDir;
            if (newDir == Vector3.zero)
            {
                OnStopMove?.Invoke();
            }
            else
            {
                OnStartMove?.Invoke();
            }
        }
    }

    public event Action OnStartMove;
    public event Action OnStopMove;
    public event Action OnJumpInputDown;
    public event Action OnJumpInputUp;
    public event Action OnDodgeInputDown;
    public event Action OnChangeCharacter1InputEvent;
    public event Action OnChangeCharacter2InputEvent;
    public event Action OnChangeCharacter3InputEvent;
    public event Action OnQuickSlot1InputEvent;
    public event Action OnQuickSlot2InputEvent;
    public event Action OnQuickSlot3InputEvent;
    public event Action OnQuickSlot4InputEvent;
    public event Action OnQuickSlot5InputEvent;

    public void JumpInputDownEvent()
    {
        OnJumpInputDown?.Invoke();
    }
    public void JumpInputUpEvent()
    {
        OnJumpInputUp?.Invoke();
    }

    public void OnDodgeInputDownEvent()
    {
        OnDodgeInputDown?.Invoke();
    }
    public void ChangeCharacter1InputEvent()
    {
        OnChangeCharacter1InputEvent?.Invoke();
    }
    public void ChangeCharacter2InputEvent()
    {
        OnChangeCharacter2InputEvent?.Invoke();
    }
    public void ChangeCharacter3InputEvent()
    {
        OnChangeCharacter3InputEvent?.Invoke();
    }
    public void QuickSlot1InputEvent()
    {
        OnQuickSlot1InputEvent?.Invoke();
    }
    public void QuickSlot2InputEvent()
    {
        OnQuickSlot2InputEvent?.Invoke();
    }
    public void QuickSlot3InputEvent()
    {
        OnQuickSlot3InputEvent?.Invoke();
    }
    public void QuickSlot4InputEvent()
    {
        OnQuickSlot4InputEvent?.Invoke();
    }
    public void QuickSlot5InputEvent()
    {
        OnQuickSlot5InputEvent?.Invoke();
    }

}
