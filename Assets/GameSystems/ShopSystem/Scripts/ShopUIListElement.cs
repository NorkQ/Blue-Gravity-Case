using UnityEngine;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ShopUIListElement : MonoBehaviour {

    [Title("Refs")]
    [SerializeField, ReadOnly] private Button m_Button;
    [SerializeField, ReadOnly] private Image m_ItemIconImage;
    [SerializeField, ReadOnly] private TMP_Text m_ItemNameText;
    [SerializeField, ReadOnly] private TMP_Text m_ItemPriceText;

    private ItemDataBase m_MyItemData;

    public delegate void ItemBuyAction(ShopUIListElement i_ItemUIShop);
    public static event ItemBuyAction OnItemBuy;

    #region Getters and setters
    #endregion

    [Button]
    private void setRefs() 
    {
        m_ItemIconImage = transform.FindDeepChild<Image>("Icon");
        m_ItemNameText = transform.FindDeepChild<TMP_Text>("Item Name");
        m_ItemPriceText = transform.FindDeepChild<TMP_Text>("Price Text");
        m_Button = gameObject.GetComponent<Button>();
    }
 
    public void Initialize(ItemDataBase i_ItemData)
    {
        m_MyItemData = i_ItemData;
        m_ItemIconImage.sprite = i_ItemData.ItemIcon;
        m_ItemNameText.text = i_ItemData.ItemName;
        m_ItemPriceText.text = "$" + i_ItemData.ItemPrice.ToString();
        m_Button.onClick.AddListener(onClick);
    }

    public void onClick()
    {
        // Para harcanacak
        Inventory.Instance.AddItem(m_MyItemData);
        OnItemBuy?.Invoke(this);
    }
}
