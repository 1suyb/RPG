using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EquipItemModel
{
    public EquipModelingKey EquipModelingKey;
    public GameObject EquipModel;
}

public class CharacterModelController : MonoBehaviour
{
    public List<EquipItemModel>EquipItemModels;
    private Dictionary<EquipModelingKey, GameObject> _equipItemModels;
    private EquipModelingKey _helmet;
    private EquipModelingKey _cloth;
    private EquipModelingKey _gloves;
    private EquipModelingKey _shoes;
    private EquipModelingKey _belt;
    private EquipModelingKey _shoulderPad;
    
    [Header("EquipPivot")]
    [SerializeField] private Transform _leftHand;
    [SerializeField] private Transform _rightHand;
    
    private void Awake()
    {
        _equipItemModels = new Dictionary<EquipModelingKey, GameObject>();
        foreach (var equipItemModel in EquipItemModels)
        {
            _equipItemModels.Add(equipItemModel.EquipModelingKey, equipItemModel.EquipModel);
        }
    }

    public void EquipItem(EquipType equipType,EquipModelingKey key)
    {
        UnEquipItem(equipType);
        switch (equipType)
        {
            case EquipType.Helmet:
                _helmet = key;
                _equipItemModels[_helmet].SetActive(true);
                break;
            case EquipType.Cloth:
                _cloth = key;
                _equipItemModels[_cloth].SetActive(true);
                break;
            case EquipType.Glove:
                _gloves = key;
                _equipItemModels[_gloves].SetActive(true);
                break;
            case EquipType.Shoe:
                _shoes = key;
                _equipItemModels[_shoes].SetActive(true);
                break;
            case EquipType.Belt:
                _belt = key;
                _equipItemModels[_belt].SetActive(true);
                break;
            case EquipType.Shoulder:
                _shoulderPad = key;
                _equipItemModels[_shoulderPad].SetActive(true);
                break;
        }
    }
    public void UnEquipItem(EquipType equipType)
    {
        switch (equipType)
        {
            case EquipType.Helmet:
                _equipItemModels[_helmet].SetActive(false);
                break;
            case EquipType.Cloth:
                _equipItemModels[_cloth].SetActive(false);
                break;
            case EquipType.Glove:
                _equipItemModels[_gloves].SetActive(false);
                break;
            case EquipType.Shoe:
                _equipItemModels[_shoes].SetActive(false);
                break;
            case EquipType.Belt:
                _equipItemModels[_belt].SetActive(false);
                break;
            case EquipType.Shoulder:
                _equipItemModels[_shoulderPad].SetActive(false);
                break;
        }
    }

#if UNITY_EDITOR
    [ContextMenu("SetList")]
    public void SetList()
    {
        string[] equipModelingKeys = Enum.GetNames(typeof(EquipModelingKey));
        foreach (Transform item in this.transform)
        {
            for(int i = 0; i < equipModelingKeys.Length; i++)
            {
                if (item.name.Contains(equipModelingKeys[i]))
                {
                    EquipItemModels.Add(new EquipItemModel{EquipModelingKey = (EquipModelingKey)Enum.Parse(typeof(EquipModelingKey),equipModelingKeys[i]),EquipModel = item.gameObject});
                }
            }
        }
    }
    #endif
}
