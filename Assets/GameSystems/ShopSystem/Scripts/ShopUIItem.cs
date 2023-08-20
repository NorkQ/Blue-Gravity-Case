using UnityEngine;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ShopUIItem : MonoBehaviour, IPointerClickHandler {
 
    [Title("Refs")]
    [SerializeField, ReadOnly] private Image m_ItemIconImage;
    [SerializeField, ReadOnly] private TMP_Text m_ItemNameText;
    [SerializeField, ReadOnly] private TMP_Text m_ItemPriceText;

    private ItemDataBase m_MyItemData;

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
        m_MyItemData = i_ItemData;
        m_ItemIconImage.sprite = i_ItemData.ItemIcon;
        m_ItemNameText.text = i_ItemData.ItemName;
        m_ItemPriceText.text = "$" + i_ItemData.ItemPrice.ToString();
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        // Para harcanacak
        Inventory.Instance.AddItem(m_MyItemData);
    }
}
