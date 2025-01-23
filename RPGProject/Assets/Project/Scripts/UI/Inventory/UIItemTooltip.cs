using System.Text;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.Serialization;

public class UIItemTooltip : MonoBehaviour
{
    [Header("UI Element")]
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private UIInventorySlot _icon;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _itemType;
    [SerializeField] private TMP_Text _option;
    [SerializeField] private TMP_Text _description;
    [SerializeField] private TMP_Text _additionalOption;
    [SerializeField] private TMP_Text _acquiredFrom;

    [Header("layout")]
    [SerializeField] private float _padding;
    [SerializeField] private float _spacing;
    [SerializeField] private float _maxWidth;
    [SerializeField] private float _iconSize;
    
    [Header("Font Size")]
    [SerializeField] private float _nameSize;
    [SerializeField] private float _itemTypeSize;
    [SerializeField] private float _optionSize;
    [SerializeField] private float _descriptionSize;
    [SerializeField] private float _addtionalOptionSize;
    [SerializeField] private float _acquiredFromSize;
    
    [Header("OneLine Max Length")]
    [SerializeField] private int _nameMaxLength;
    [SerializeField] private int _itemTypeMaxLength;
    [SerializeField] private int _optionMaxLength;
    [SerializeField] private int _descriptionMaxLength;
    [SerializeField] private int _addtionalOptionMaxLength;
    [SerializeField] private int _acquiredFromMaxLength;

    private int _nameLines;
    private int _itemTypeLines;
    private int _optionLines;
    private int _descriptionLines;
    private int _additionalOptionLines;
    private int _acquiredFromLines;

    private RectTransform _iconRectTransform;

    public void SetPosition(Vector2 position)
    {
        position.x -= _rectTransform.sizeDelta.x;
        _rectTransform.position = position;
    }
    public void OpenUI(Item item)
    {
        if(_iconRectTransform == null)
        {
            _iconRectTransform = _icon.GetComponent<RectTransform>();
        }
        if(item == null)
        {
            return;
        }
        _icon.UpdateSlot(item.ItemData.Sprite,item.Count);
        switch (item.ItemType)
        {
            case ItemType.Equipment :
                SetEquipText(item.ItemData);
                break;
            case ItemType.Consume :
                SetConsumeText(item.ItemData);
                break;
            case ItemType.Material :
                SetMaterialText(item.ItemData);
                break;
        }
        SetLayout();
        _rectTransform.gameObject.SetActive(true);
    }

    public void CloseUI()
    {
        _name.text = "";
        _itemType.text = "";
        _option.text = "";
        _description.text = "";
        _additionalOption.text = "";
        _acquiredFrom.text = "";
        
        _nameLines = 0;
        _itemTypeLines = 0;
        _optionLines = 0;
        _descriptionLines = 0;
        _additionalOptionLines = 0;
        _acquiredFromLines = 0;
        
        _rectTransform.gameObject.SetActive(false);
    }
    
    private void SetEquipText(ItemData item)
    {
        EquipData equipData = item as EquipData;
        if(equipData == null)
        {
            return;
        }
        _name.text = equipData.Name;
        _nameLines = equipData.Name.Length / _nameMaxLength + 1;
        
        _description.text = equipData.Description;
        _descriptionLines = equipData.Description.Length / _descriptionMaxLength + 1;
        
        StringBuilder itemType = new StringBuilder();
        itemType.AppendLine(equipData.ItemType.ToString());
        itemType.AppendLine(equipData.EquipType.ToString());
        _itemType.text = itemType.ToString();
        _itemTypeLines = itemType.Length / _itemTypeMaxLength + 1;
        
        EquipItemInfo equipItemInfo = equipData.EquipItemInfo;
        _optionLines = 0;
        if (equipItemInfo != null)
        {
            StringBuilder option = new StringBuilder();
            if (equipItemInfo.PhysicalAttack != 0)
            {
                option.AppendLine($"물리공격력 : {equipItemInfo.PhysicalAttack}");
                _optionLines += 1;
            }

            if (equipItemInfo.MagicalAttack != 0)
            {
                option.AppendLine($"마법공격력 : {equipItemInfo.MagicalAttack}");
                _optionLines += 1;
            }

            if (equipItemInfo.PhysicalDefence != 0)
            {
                option.AppendLine($"물리방어력 : {equipItemInfo.PhysicalDefence}");
                _optionLines += 1;
            }
            if(equipItemInfo.MagicalDefence != 0)
            {
                option.AppendLine($"마법방어력 : {equipItemInfo.MagicalDefence}");
                _optionLines += 1;
            }
            if (equipItemInfo.MaxHp != 0)
            {
                option.AppendLine($"최대 체력 : {equipItemInfo.MaxHp}");
                _optionLines += 1;
            }
            if (equipItemInfo.MaxMp != 0)
            {
                option.AppendLine($"최대 마나 : {equipItemInfo.MaxMp}");
                _optionLines += 1;
            }
            if (equipItemInfo.MaxShield != 0)
            {
                option.AppendLine($"최대 쉴드 : {equipItemInfo.MaxShield}");
                _optionLines += 1;
            }
            if (equipItemInfo.MaxHunger != 0)
            {
                option.AppendLine($"최대 허기 : {equipItemInfo.MaxHunger}");
                _optionLines += 1;
            }
            if (equipItemInfo.CriticalChance != 0)
            {
                option.AppendLine($"치명타 확률 : {equipItemInfo.CriticalChance}");
                _optionLines += 1;
            }
            if (equipItemInfo.CriticalMultiplier != 0)
            {
                option.AppendLine($"치명타 배율 : {equipItemInfo.CriticalMultiplier}");
                _optionLines += 1;
            }
            if(equipItemInfo.Level != 0)
            {
                option.AppendLine($"착용제한 레벨 : {equipItemInfo.Level}");
                _optionLines += 1;
            }
            _option.text = option.ToString();

        }
        _additionalOptionLines = 0;
        _acquiredFromLines = 0;
        
    }
    private void SetConsumeText(ItemData item)
    {
        ConsumableData consumableData = item as ConsumableData;
        if(consumableData == null)
        {
            return;
        }
        _name.text = consumableData.Name;
        _nameLines = consumableData.Name.Length / _nameMaxLength + 1;
        
        _description.text = consumableData.Description;
        _descriptionLines = consumableData.Description.Length / _descriptionMaxLength + 1;
        
        _itemType.text = consumableData.ItemType.ToString();
        _itemTypeLines = 1;
        
        _option.text = "";
        _optionLines = 0;
        
        _additionalOption.text = "";
        _additionalOptionLines = 0;
        
        _acquiredFrom.text = "";
        _acquiredFromLines = 0;
        
    }
    private void SetMaterialText(ItemData item)
    {
        
    }

    private void SetLayout()
    {
        Vector2 iconPosition = new Vector2(_padding, -_padding);
        Vector2 iconSize = new Vector2(_iconSize, _iconSize);
        SetLocalPositionandSize(_iconRectTransform,iconPosition,iconSize);
        
        Vector2 namePosition = new Vector2(iconPosition.x + iconSize.x + _spacing, -_padding);
        Vector2 nameTextObjSize = new Vector2(_maxWidth - iconSize.x - _spacing * 2, _nameSize * _nameLines);
        SetLocalPositionandSize(_name.rectTransform,namePosition,nameTextObjSize);

        
        Vector2 itemTypePosition = new Vector2(namePosition.x, namePosition.y - nameTextObjSize.y - _spacing);
        Vector2 itemTypeTextObjSize = new Vector2(_maxWidth - iconSize.x - _spacing*2, _itemTypeSize * _itemTypeLines);
        SetLocalPositionandSize(_itemType.rectTransform,itemTypePosition,itemTypeTextObjSize);


        Vector2 optionPosition = new Vector2(_padding,
            Mathf.Min(iconPosition.y - iconSize.y - _spacing, itemTypePosition.y - itemTypeTextObjSize.y - _spacing));
        Vector2 optionTextObjSize = new Vector2(_maxWidth - _padding*2, _optionSize * _optionLines);
        SetLocalPositionandSize(_option.rectTransform,optionPosition,optionTextObjSize);
        
        Vector2 descriptionPosition = new Vector2(_padding, optionPosition.y- optionTextObjSize.y);
        if (_optionLines > 0) descriptionPosition.y -= _spacing;
        Vector2 descriptionTextObjSize = new Vector2(_maxWidth - _padding*2, _descriptionSize * _descriptionLines);
        SetLocalPositionandSize(_description.rectTransform,descriptionPosition,descriptionTextObjSize);
        
        Vector2 additionalOptionPosition = new Vector2(_padding, descriptionPosition.y - descriptionTextObjSize.y - _spacing);
        Vector2 additionalOptionTextObjSize = new Vector2(_maxWidth - _padding*2, _addtionalOptionSize * _additionalOptionLines);
        SetLocalPositionandSize(_additionalOption.rectTransform,additionalOptionPosition,additionalOptionTextObjSize);
        
        Vector2 acquiredFromPosition = new Vector2(_padding, additionalOptionPosition.y - additionalOptionTextObjSize.y);
        if(_additionalOptionLines > 0) acquiredFromPosition.y -= _spacing;
        Vector2 acquiredFromTextObjSize = new Vector2(_maxWidth - _padding*2, _acquiredFromSize * _acquiredFromLines);
        SetLocalPositionandSize(_acquiredFrom.rectTransform,acquiredFromPosition,acquiredFromTextObjSize);
        
        Vector2 tooltipSize = new Vector2(_maxWidth, -(acquiredFromPosition.y - acquiredFromTextObjSize.y - _padding));
        _rectTransform.sizeDelta = tooltipSize;
        
    }
    
    private void SetLocalPositionandSize(RectTransform rect,Vector2 position, Vector2 size)
    {
        rect.localPosition = position;
        rect.sizeDelta = size;
    }


}
