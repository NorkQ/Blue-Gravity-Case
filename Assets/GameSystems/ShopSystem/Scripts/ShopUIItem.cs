using UnityEngine;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class ShopUIItem : MonoBehaviour {
 
    [Title("Refs")]
    [SerializeField, ReadOnly] private Image m_ItemIconImage;
    [SerializeField, ReadOnly] private TMP_Text m_ItemNameText;
    [SerializeField, ReadOnly] private TMP_Text m_ItemPriceText;

    #region Getters and setters
    #endregion

    [Button]
    private void setRefs() 
    {
        m_ItemIconImage = transform.FindDeepChild<Image>("Icon");
        m_ItemNameText = transform.FindDeepChild<TMP_Text>("Item Name");
        m_ItemPriceText = transform.FindDeepChild<TMP_Text>("Price Text");
    }
 
    public void Initialize(ItemDataBase i_ItemData)
    {
        m_ItemIconImage.sprite = i_ItemData.ItemIcon;
        m_ItemNameText.text = i_ItemData.ItemName;
        m_ItemPriceText.text = "$" + i_ItemData.ItemPrice.ToString();
    }
}
