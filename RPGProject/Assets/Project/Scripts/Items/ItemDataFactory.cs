using Manager;

public class ItemDataFactory
{
    private ItemInfoLoader _itemLoader;
    
    private InfoLoader<ItemInfo> itemInfo => _itemLoader.ItemLoader;
    private InfoLoader<EquipItemInfo> equipItemInfo => _itemLoader.EquipItemLoader;
    private InfoLoader<ConsumeItemInfo> consumeItemInfo => _itemLoader.ConsumeItemLoader;
    private InfoLoader<MaterialItemInfo> materialItemInfo => _itemLoader.MaterialItemLoader;
    
    
    public ItemDataFactory()
    {
        _itemLoader = Managers.InfoManager.ItemInfoLoader;
    }
    
    public ItemData CreateItem(int infoID, int count = 0)
    {
        ItemInfo info = itemInfo.GetItem(infoID);
        return CreateItem(info, count);
    }
    public ItemData CreateItem(ItemInfo info, int count = 0)
    {
        switch (info.ItemType)
        {
            case ItemType.Equipment:
                EquipItemInfo equipInfo = equipItemInfo.GetItem(info.EquipID);
                return new EquipData(info,equipInfo, count);
            case ItemType.Consume:
                ConsumeItemInfo consumeInfo = consumeItemInfo.GetItem(info.ComsumeID);
                return new ConsumableData(info,consumeInfo, count);
            case ItemType.Material:
                MaterialItemInfo materialInfo = materialItemInfo.GetItem(info.ResourceID);
                return new MaterialData(info,materialInfo, count);
            default:
                return new ItemData(info, count);
        }
    }
}