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
    [SerializeField] private GameObject _itemMenuButtonPrefab;
    
    [Header("Tooltip")]
    [SerializeField] private UIItemTooltip _itemTooltip;


    private InventoryController _inventoryController;
    
    private int _slotCount = 48;
    private List<UIInventorySlot> _slotList = new List<UIInventorySlot>();
    private int _heldSlotIndex = -1;
    
    private List<Button> _actionPopupButtons = new List<Button>();
    
    #region Init
    public void InitOnCreate(InventoryController inventoryController)
    {
        _inventoryController = inventoryController;
        for(int i = 0 ; i<3;i++)
        {
            GameObject buttonObject = Instantiate(_itemMenuButtonPrefab, _slotParent.parent);
            Button button = buttonObject.GetComponent<Button>();
            _actionPopupButtons.Add(button);
            button.gameObject.SetActive(false);
        }
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

    private void OpenActionPopup()
    {
        Vector3 pivotPoint = _slotList[_heldSlotIndex].transform.position - Vector3.up*_slotList[_heldSlotIndex].GetComponent<RectTransform>().rect.height/2;
        for(int i = 0; i< _actionPopupButtons.Count; i++)
        {
            _actionPopupButtons[i].gameObject.SetActive(true);
            _actionPopupButtons[i].transform.position = pivotPoint;
            pivotPoint += new Vector3(0, -_actionPopupButtons[i].GetComponent<RectTransform>().rect.height, 0);
        }
    }

    private void CloseActionPopup()
    {
        for(int i = 0 ; i < _actionPopupButtons.Count; i++)
        {
            _actionPopupButtons[i].gameObject.SetActive(false);
        }
    }
    
    public void UpdateUI(ItemData[] datas)
    {
        for(int i = 0 ; i< _slotList.Count; i++)
        {
            if(datas[i]!=null)
            {
                _slotList[i].UpdateSlot(datas[i].Sprite, datas[i].Count);
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

}