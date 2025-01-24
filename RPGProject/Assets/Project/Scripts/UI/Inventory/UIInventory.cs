using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : UIBase
{
    [Header("Array Buttons")]
    [SerializeField] private Button _arrayAll;
    [SerializeField] private Button _arrayEquips;
    [SerializeField] private Button _arrayConsumables;
    [SerializeField] private Button _arrayResources;
    
    [Header("transform")]
    [SerializeField] private Transform _slotParent;
    
    [Header("Prefabs")]
    [SerializeField] private GameObject _slotPrefab;
    [Header("Tooltip")]
    [SerializeField] private UIItemTooltip _itemTooltip;
    [Header("ItemActionPopup")]
    [SerializeField] private UIItemActionPopup _itemActionPopup;

    private InventoryController _inventoryController;
    
    private int _slotCount = 48;
    private List<UIInventorySlot> _slotList = new List<UIInventorySlot>();
    private int _heldSlotIndex = -1;
    
    private List<Button> _actionPopupButtons = new List<Button>();
    
    #region Init
    public void InitOnCreate(InventoryController inventoryController)
    {
        _inventoryController = inventoryController;
        InitSlot();
        _arrayAll.onClick.AddListener(() => _inventoryController.ArrayAll());
        _arrayEquips.onClick.AddListener(() => _inventoryController.ArrayEquips());
        _arrayConsumables.onClick.AddListener(() => _inventoryController.ArrayConsumables());
        _arrayResources.onClick.AddListener(() => _inventoryController.ArrayResources());
        
    }

    private void InitSlot()
    {
        for(int i = 0; i < _slotCount; i++)
        {
            GameObject slotObject = Instantiate(_slotPrefab, _slotParent);
            UIInventorySlot slot = slotObject.GetComponent<UIInventorySlot>();
            slot.InitOnCreate(i,this);
            slot.AddEvents(
                enter: () => OpenTooltip(slot.Index),
                exit: CloseTooltip,
                down: () => HoldSlot(slot.Index),
                click: OpenActionPopup,
                beginDrag: CloseActionPopup,
                drop:()=>Swap(slot.Index)
                );
            _slotList.Add(slot);
        }
    }
    #endregion
    
    public void UpdateUI(Item[] datas)
    {
        for(int i = 0 ; i< _slotList.Count; i++)
        {
            if(datas[i]!=null)
            {
                _slotList[i].UpdateSlot(datas[i].ItemData.Sprite, datas[i].Count);
            }
            else
            {
                _slotList[i].UpdateSlot(null,0);
            }
        }
    }

    public void HoldSlot(int index)
    {
        if(_heldSlotIndex!=index) CloseActionPopup();
        _heldSlotIndex = index;
        Debug.Log("HoldSlot : " + _heldSlotIndex);
        
    }
    public void Swap(int to)
    {
        _inventoryController.Swap(_heldSlotIndex, to);
    }

    
    
    #region Tooltip
    
    public void OpenTooltip(int index)
    {
        UIInventorySlot slot = _slotList[index];
        RectTransform slotRect = slot.GetComponent<RectTransform>();
        Vector2 position = slotRect.position;
        position.x -= slotRect.rect.width*slot.ScaleValue/2;
        position.y += slotRect.rect.height*slot.ScaleValue/2;
        _itemTooltip.SetPosition(position);
        _itemTooltip.OpenUI(_inventoryController.GetItemData(index));
    }
    public void CloseTooltip()
    {
        _itemTooltip.CloseUI();
    }
    
    #endregion

    #region ActionPopup
    private void OpenActionPopup()
    {
        UIInventorySlot slot = _slotList[_heldSlotIndex];
        if(slot.IsNull) return;
        _itemActionPopup.OpenActionPopup(slot.GetComponent<RectTransform>(),
            _inventoryController.GetItemData(_heldSlotIndex));
        _itemActionPopup.AddEvent(new Action[]
        {
            ()=>_inventoryController.UseItem(_heldSlotIndex),
            ()=>_inventoryController.DropItem(_heldSlotIndex)
        });
    }

    private void CloseActionPopup()
    {
        _itemActionPopup.CloseActionPopup();
    }
    #endregion

}