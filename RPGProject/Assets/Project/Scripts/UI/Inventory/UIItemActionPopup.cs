using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIItemActionPopup : MonoBehaviour
{
    [SerializeField] private GameObject _itemMenuButtonPrefab;
    private List<Button> _actionPopupButtons = new List<Button>();
    private List<TMP_Text> _actionPopupTexts = new List<TMP_Text>();
    public void Awake()
    {
        for(int i = 0 ; i<3;i++)
        {
            GameObject buttonObject = Instantiate(_itemMenuButtonPrefab, this.transform);
            Button button = buttonObject.GetComponent<Button>();
            _actionPopupButtons.Add(button);
            button.gameObject.SetActive(false);
            TMP_Text text = buttonObject.GetComponentInChildren<TMP_Text>();
            _actionPopupTexts.Add(text);
        }
    }
    
    public void OpenActionPopup(RectTransform slotTransform, Item item)
    {
        Vector3 pivotPoint = slotTransform.position - Vector3.up * slotTransform.rect.height / 2;
        for(int i = 0; i< _actionPopupButtons.Count; i++)
        {
            _actionPopupButtons[i].transform.position = pivotPoint;
            pivotPoint += new Vector3(0, -_actionPopupButtons[i].GetComponent<RectTransform>().rect.height, 0);

        }
        switch (item.ItemType)
        {
            case ItemType.Equipment :
                EquipItem equipItem = item as EquipItem;
                _actionPopupTexts[0].text = "장착하기";
                if (equipItem == null) return;
                _actionPopupTexts[0].text = equipItem.IsEquipped ? "장착해제" : "장착하기";
                _actionPopupTexts[1].text = "버리기";
                break;
            case ItemType.Consume:
                _actionPopupTexts[0].text = "사용하기";
                _actionPopupTexts[1].text = "버리기";
                break;
            case ItemType.Material:
                _actionPopupTexts[0].text = "버리기";
                break;
        }
    }

    public void AddEvent(Action[] actions = null)
    {
        if (actions == null)
        {
            return;
        }
        for (int i = 0; i < actions.Length; i++)
        {
            int index = i;
            _actionPopupButtons[i].onClick.AddListener(()=>actions[index].Invoke());
            _actionPopupButtons[i].gameObject.SetActive(true);
        }
    }
    public void CloseActionPopup()
    {
        for(int i = 0 ; i < _actionPopupButtons.Count; i++)
        {
            _actionPopupButtons[i].onClick.RemoveAllListeners();
            _actionPopupButtons[i].gameObject.SetActive(false);
        }
    }
}
