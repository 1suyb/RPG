using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipPart
{
    Helmet = 0,
    Armor = 1,
    Belt = 2,
    Shoulder = 3,
    Shoes = 4,
    Weapon = 5
}

public class CharacterEquipmentHandler : MonoBehaviour
{
    private EquipItem[] _equipItems = new EquipItem[7];
    [SerializeField] private Character _character;
    private StatHandler _statHandler => _character.StatHandler;
    
    public void Init(Character character)
    {
        _character = character;
    }
    
    public void Equip(EquipItem item)
    {
        int index = Mathf.Clamp((int)item.ItemData.ItemType, 0, 6);
        if (_equipItems[index] != null)
        {
            EquipItem equipItem = _equipItems[index];
            UnequipItem(equipItem);
        }
        item.IsEquipped = true;
        _equipItems[index] = item;
        _statHandler.AddAdjustStat(item.Stat);
    }
    
    public void UnequipItem(EquipItem item)
    {
        if (!item.IsEquipped) return;
        int index = Mathf.Clamp((int)item.ItemData.ItemType, 0, 6);
        _statHandler.SubtractAdjustStat(item.Stat);
        item.IsEquipped = false;
        _equipItems[index] = null;
    }
}
