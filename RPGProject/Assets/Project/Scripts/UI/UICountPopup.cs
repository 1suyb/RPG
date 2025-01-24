using System;
using Manager;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UICountPopup : UIBase
{
    [SerializeField] private TMP_Text _titleText;
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private Button _plusButton;
    [SerializeField] private Button _minusButton;
    [SerializeField] private Button _yesButton;

    private Action<int> _onYesButton;
    private int _maxCount;
    private int _currentCount;

    public void Setup(string title, int maxCount, Action<int> onYesButton)
    {
        _titleText.text = title;
        _maxCount = maxCount;
        _currentCount = 1;
        _inputField.text = _currentCount.ToString();
        _onYesButton = onYesButton;
        _yesButton.onClick.AddListener(() =>
        {
            _onYesButton?.Invoke(_currentCount);
            UIManager.Instance.Close<UICountPopup>(UIType.CountPopup);
        });
        _plusButton.onClick.AddListener(CountPlus);
        _minusButton.onClick.AddListener(CountMinus);
    }

    public override void CloseProcedure()
    {
        _plusButton.onClick.RemoveAllListeners();
        _minusButton.onClick.RemoveAllListeners();
        _yesButton.onClick.RemoveAllListeners();
        _inputField.text = "1";
    }

    public void CountPlus()
    {
        if (_currentCount >= _maxCount)
        {
            return;
        }
        _currentCount++;
        _inputField.text = _currentCount.ToString();
    }
    
    public void CountMinus()
    {
        if (_currentCount <= 1)
        {
            return;
        }
        _currentCount--;
        _inputField.text = _currentCount.ToString();
    }
    
}
