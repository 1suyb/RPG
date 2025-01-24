using Manager;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    private Character _character;
    private Inventory _inventory;
    private UIInventory _uiInventory;
    [SerializeField] private InputEventListenerSO _openInventoryEvent;
    
    private bool _isInventoryUIOpen = false;

    private void Awake()
    {
        _character = GetComponent<Character>();
        _inventory = new Inventory();
        _uiInventory = UIManager.Instance.Get<UIInventory>(UIType.Inventory);
        _uiInventory.InitOnCreate(this);
        _openInventoryEvent.OnInventoryInputEvent += OpenInventory;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            AddItem(Managers.InfoManager.ItemInfoLoader.ItemLoader.GetItem(7),1);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            AddItem(Managers.InfoManager.ItemInfoLoader.ItemLoader.GetItem(12),12);
        }
        
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
    
    public void DropItem(int index)
    {
        Item item = _inventory[index];
        if (item == null) return;
        UIManager.Instance.CountPopup("몇개를 버리시겠습니까?",item.Count, (count) => ExcuteDropItem(index, count));
    }
    void ExcuteDropItem(int index, int count)
    {
        _inventory.RemoveItem(index, count);
        UpdateUI();
    }

    public void Swap(int i, int j)
    {
        _inventory.Swap(i, j);
        UpdateUI();
    }

    public Item GetItemData(int index)
    {
        return _inventory[index];
    }
    
    private void UpdateUI(Item[] datas = null)
    {
        _uiInventory.UpdateUI(datas ?? _inventory.ItemList);
    }

    public void UseItem(int index)
    {
        _inventory.UseAtItem(index,_character);
        UpdateUI();
    }
}
