using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour, PlayerInput.IPlayerActions
{
    [SerializeField] private InputEventListenerSO _inputEventListenerSo;
    [SerializeField] private LayerMask _groundLayer;
    private PlayerInput _input;
    private PlayerInput.PlayerActions _playerActions;
    
    private Camera _mainCamera;
    private void Awake()
    {
        _input = new PlayerInput();
        _playerActions = _input.Player;
        _playerActions.Enable();
        _playerActions.SetCallbacks(this);
    }

    private void Start()
    {
        _mainCamera = Camera.main;
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        Vector3 lookDir = context.ReadValue<Vector2>();

        Ray ray = _mainCamera.ScreenPointToRay(lookDir);
        if (Physics.Raycast(ray,out RaycastHit hit, 100f, layerMask:_groundLayer.value))
        {
            _inputEventListenerSo.SetLookDir(new Vector2(hit.point.x,hit.point.z));
        }
       
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _inputEventListenerSo.SetMoveDir(context.ReadValue<Vector2>());
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.canceled)
            _inputEventListenerSo.JumpInputUpEvent();
    }

    public void OnDodge(InputAction.CallbackContext context)
    {
        if(context.performed)
            _inputEventListenerSo.OnDodgeInputDownEvent();
    }

    public void OnInteraction(InputAction.CallbackContext context)
    {
        
    }

    public void OnChangeCharacter1(InputAction.CallbackContext context)
    {
        _inputEventListenerSo.ChangeCharacter1InputEvent();
    }

    public void OnChangeCharacter2(InputAction.CallbackContext context)
    {
        _inputEventListenerSo.ChangeCharacter2InputEvent();
    }

    public void OnChangeCharacter3(InputAction.CallbackContext context)
    {
        _inputEventListenerSo.ChangeCharacter3InputEvent();
    }

    public void OnQuickSlot1(InputAction.CallbackContext context)
    {
        _inputEventListenerSo.QuickSlot1InputEvent();
    }

    public void OnQuickSlot2(InputAction.CallbackContext context)
    {
        _inputEventListenerSo.QuickSlot2InputEvent();
    }

    public void OnQuickSlot3(InputAction.CallbackContext context)
    {
        _inputEventListenerSo.QuickSlot3InputEvent();
    }

    public void OnQuickSlot4(InputAction.CallbackContext context)
    {
        _inputEventListenerSo.QuickSlot4InputEvent();
    }

    public void OnQuickSlot5(InputAction.CallbackContext context)
    {
        _inputEventListenerSo.QuickSlot5InputEvent();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if(context.performed)
            _inputEventListenerSo.AttackInputDownEvent();
        else if(context.canceled)
            _inputEventListenerSo.AttackInputUpEvent();
    }

    public void OnCombatToggle(InputAction.CallbackContext context)
    {
        if(context.performed)
            _inputEventListenerSo.EquipChangeInputEvent();
    }
    public void OnInventory(InputAction.CallbackContext context)
    {
        if(context.performed)
            _inputEventListenerSo.InventoryInputEvent();
    }
}
