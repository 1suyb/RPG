using System.Collections.Generic;
using Manager;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    private Inventory _inventory;
    private UIInventory _uiInventory;
    [SerializeField] private InputEventListenerSO _openInventoryEvent;
    
    private bool _isInventoryUIOpen = false;

    private void Awake()
    {
        _inventory = new Inventory();
        _uiInventory = UIManager.Instance.Get<UIInventory>(UIType.Inventory);
        _uiInventory.InitOnCreate(this);
        _openInventoryEvent.OnInventoryInputEvent += OpenInventory;
    }

    public void OpenInventory()
    {
        if (!_isInventoryUIOpen)
        {
            UIManager.Instance.Open<UIInventory>(UIType.Inventory);
            UpdateUI();
        }
        else
        {
            UIManager.Instance.Close<UIInventory>(UIType.Inventory);
        }
        _isInventoryUIOpen = !_isInventoryUIOpen;
    }
    
    public void ArrayAll()
    {
        UpdateUI(_inventory.ItemList);
    }
    public void ArrayEquips()
    {
        //List<ItemData> equips = _inventory.ItemList.FindAll(x => x.ItemType == ItemType.Equip);
        //UpdateUI(equips);
    }
    public void ArrayConsumables()
    {
        //List<ItemData> consumables = _inventory.ItemList.FindAll(x => x.ItemType == ItemType.Consumable);
        //UpdateUI(consumables);
    }
    public void ArrayResources()
    {
        //List<ItemData> resources = _inventory.ItemList.FindAll(x => x.ItemType == ItemType.Resource);
        //UpdateUI(resources);
    }

    public void AddItem(ItemInfo item, int count)
    {
        int remainCount = _inventory.AddItem(item, count);
        UpdateUI();
        if (remainCount > 0)
        {
            Debug.Log("Inventory is full");
        }
    }
    
    public void DropItem(ItemData item)
    {
        //_inventory.DropItem(item);
        UpdateUI();
    }

    private void UpdateUI(List<ItemData> datas = null)
    {
        _uiInventory.UpdateUI(datas==null?_inventory.ItemList:datas);
    }
}
