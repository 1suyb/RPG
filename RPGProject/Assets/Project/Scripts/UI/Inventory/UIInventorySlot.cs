using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class UIInventorySlot : UISlot, IPointerDownHandler, IPointerUpHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    private UIInventory _inventoryUI;
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

    private int _index;
    public int Index => _index;
    
    private Action _onPointerDown;
    private Action _onPointerUp;
    private Action _onBeginDrag;
    private Action _onEndDrag;
    private Action _onDrag;
    private Action _onDrop;
    
    public bool IsNull = true;
    private bool _isDragging = false;
    public void InitOnCreate(int index, UIInventory inventoryUI)
    {
        _index = index;
        _inventoryUI = inventoryUI;
    }
    
    public void UpdateSlot(Sprite sprite, int count)
    {
        IsNull = sprite == null;
        Sprite = sprite;
        Count = count;
    }

    public void AddEvents(Action click = null, Action enter = null, Action exit = null, Action down = null,
        Action up = null, Action beginDrag = null, Action endDrag = null, Action drag = null, Action drop = null)
    {
        base.AddEvents(click, enter, exit);
        _onPointerDown = down;
        _onPointerUp = up;
        _onBeginDrag = beginDrag;
        _onEndDrag = endDrag;
        _onDrag = drag;
        _onDrop = drop;
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        _onPointerDown?.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _onPointerUp?.Invoke();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _onBeginDrag?.Invoke();
        if (!IsNull)
        {
            _isDragging = true;
            _icon.rectTransform.SetParent(_inventoryUI.transform, false);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _onEndDrag?.Invoke();
        if (_isDragging)
        {
            _icon.rectTransform.SetParent(transform, false);
            _icon.rectTransform.position = transform.position;
            _isDragging = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        _onDrag?.Invoke();
        if(_isDragging)
            _icon.rectTransform.position = eventData.position;
    }

    public void OnDrop(PointerEventData eventData)
    {
        _onDrop?.Invoke();
    }
}
