using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
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

    private InventoryController _inventoryController;
    
    private int _slotCount = 48;
    private List<UIInventorySlot> _slotList = new List<UIInventorySlot>();
    
    
    public void InitOnCreate(InventoryController inventoryController)
    {
        _inventoryController = inventoryController;
        InitSlot();
        _arrayAll.onClick.AddListener(() => _inventoryController.ArrayAll());
        _arrayEquips.onClick.AddListener(() => _inventoryController.ArrayEquips());
        _arrayConsumables.onClick.AddListener(() => _inventoryController.ArrayConsumables());
        _arrayResources.onClick.AddListener(() => _inventoryController.ArrayResources());
    }

    public void UpdateUI(List<ItemData> datas)
    {
        for(int i = 0 ; i< _slotList.Count; i++)
        {
            if(i < datas.Count)
            {
                _slotList[i].UpdateSlot(datas[i].Sprite, datas[i].Count);
            }
            else
            {
                _slotList[i].UpdateSlot(null,0);
            }
        }
    }
    private void InitSlot()
    {
        for(int i = 0; i < _slotCount; i++)
        {
            GameObject slotObject = Instantiate(_slotPrefab, _slotParent);
            UIInventorySlot slot = slotObject.GetComponent<UIInventorySlot>();
            _slotList.Add(slot);
        }
    }
}