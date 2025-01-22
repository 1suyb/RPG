using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UISlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [Header("Dotween")]
    [SerializeField] private float _scaleDuration = 0.1f;
    [SerializeField] private float _scaleValue = 1.1f;
    [SerializeField] private Transform _animationTween;
    
    [Header("UI")]
    [Tooltip("인터렉션 가능한 슬롯인지")][SerializeField] private bool _isInteractive;
    [SerializeField] protected Image _icon;
    
    public float ScaleValue => _scaleValue;
    
    private Action _enterAction;
    private Action _exitAction;
    private Action _clickAction;
    
    private Tween _pointerEnterTween;
    private Tween _pointerExitTween;
    private Tween _pointerClickTween;

    private Sprite _sprite;
    public Sprite Sprite
    {
        get => _sprite;
        set
        {
            _sprite = value;
            _icon.sprite = _sprite;
        }
    }

    private void Awake()
    {
        InitTween();
    }
    
    public void AddEvents(Action click, Action enter, Action exit)
    {
        _clickAction = click;
        _enterAction = enter;
        _exitAction = exit;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _enterAction?.Invoke();
        if(_isInteractive) _pointerEnterTween.Restart();
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        _exitAction?.Invoke();
        if(_isInteractive) _pointerExitTween.Restart();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _clickAction?.Invoke();
        if(_isInteractive) _pointerClickTween.Restart();
    }
    protected virtual void InitTween()
    {
        _pointerEnterTween = _animationTween.DOScale(_scaleValue, _scaleDuration).SetEase(Ease.OutBack).SetAutoKill(false).Pause();
        _pointerExitTween = _animationTween.DOScale(1f, _scaleDuration).SetEase(Ease.InBack).SetAutoKill(false).Pause();
    }
}