using TMPro;
using UnityEngine;

public class UIInventorySlot : UISlot
{
    [SerializeField] private TextMeshProUGUI _countText;
    
    private int _count;
    public int Count
    {
        get => _count;
        set
        {
            _count = value;
            _countText.text = _count <= 1 ? "" : _count.ToString();
        }
    }

    public void UpdateSlot(Sprite sprite, int count)
    {
        Sprite = sprite;
        Count = count;
    }
    
}
