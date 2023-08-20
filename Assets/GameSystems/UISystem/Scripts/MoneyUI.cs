using UnityEngine;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using DG.Tweening;
using TMPro;
 
public class MoneyUI : MonoBehaviour {
 
    [Title("Refs")]
    [SerializeField, ReadOnly] private TMP_Text m_MoneyText;
 
    #region Getters and setters
    #endregion
 
    [Button]
    private void setRefs() 
    {
        m_MoneyText = transform.FindDeepChild<TMP_Text>("Info Text");
    }
 
    private void OnEnable() 
    {
        MoneyManager.OnMoneyAmountChange += updateMoneyText;
        updateMoneyText();
    }
 
    private void OnDisable() 
    {
        MoneyManager.OnMoneyAmountChange -= updateMoneyText;
    }

    private void updateMoneyText()
    {
        m_MoneyText.text = "$" + MoneyManager.Instance.CurrentMoney;
    }
}
