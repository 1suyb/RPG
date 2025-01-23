using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Manager
{
    public class InfoManager : IManager
    {
        public ItemInfoLoader ItemInfoLoader { get; private set; }
        public void InitOnCreate()
        {
            ItemInfoLoader = new ItemInfoLoader();
        }

        public void Release()
        {
            throw new System.NotImplementedException();
        }
    }

    public class ItemInfoLoader
    {
        public InfoLoader<ItemInfo> ItemLoader { get; private set; }
        public InfoLoader<EquipItemInfo> EquipItemLoader { get; private set; }
        public InfoLoader<ConsumeItemInfo> ConsumeItemLoader { get; private set; }
        public InfoLoader<MaterialItemInfo> MaterialItemLoader { get; private set; }
        public InfoLoader<BuffInfo> BuffLoader { get; private set; }
        public InfoLoader<EffectInfo> EffectLoader { get; private set; }
        
        public ItemInfoLoader()
        {
            ItemLoader = new InfoLoader<ItemInfo>();
            EquipItemLoader = new InfoLoader<EquipItemInfo>();
            ConsumeItemLoader = new InfoLoader<ConsumeItemInfo>();
            MaterialItemLoader = new InfoLoader<MaterialItemInfo>();
            BuffLoader = new InfoLoader<BuffInfo>();
            EffectLoader = new InfoLoader<EffectInfo>();
        }
    }

}
