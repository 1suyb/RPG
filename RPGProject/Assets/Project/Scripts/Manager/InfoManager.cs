using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Manager
{
    public class InfoManager : IManager
    {
        public InfoLoader<ItemInfo> ItemLoader { get; private set; }
        public InfoLoader<EquipItemInfo> EquipItemLoader { get; private set; }
        public void InitOnCreate()
        {
            ItemLoader = new InfoLoader<ItemInfo>();
            EquipItemLoader = new InfoLoader<EquipItemInfo>();
        }

        public void Release()
        {
            throw new System.NotImplementedException();
        }
    }

}
