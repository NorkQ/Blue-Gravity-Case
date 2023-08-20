using UnityEngine;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

// Items in the shopping panel. Player can buy items by clicking on this object.
public class ShopUIListElement : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    [Title("Refs")]
    [SerializeField, ReadOnly] private Button m_Button;
    [SerializeField, ReadOnly] private Image m_ItemIconImage;
    [SerializeField, ReadOnly] private TMP_Text m_ItemNameText;
    [SerializeField, ReadOnly] private TMP_Text m_ItemPriceText;

    [Title("Manual Refs")]
    [SerializeField] private AudioClip m_BuySFX;

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
 
    // Set icons, titles, descriptions, buttons etc.
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
        // If money is not enough, player can't buy this item.
        if (!MoneyManager.Instance.CheckIsMoneyEnough(m_MyItemData.ItemPrice))
        {
            // You can't buy this item warning.
            UIManager.Instance.OpenWarningPanel(GeneralConfig.Instance.NotEnoughMoneyWarning);
            return;
        }

        // Buy item and add it to inventory
        AudioManager.Instance.PlaySFX(m_BuySFX);
        Inventory.Instance.AddItem(m_MyItemData);

        // Consume money by item price
        MoneyManager.Instance.ConsumeMoney(m_MyItemData.ItemPrice);
        OnItemBuy?.Invoke(this);
    }

    // To update info box
    public void OnPointerEnter(PointerEventData eventData)
    {
        UIManager.Instance.OpenShopInfoboxPanel(m_MyItemData.ItemDescription);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        UIManager.Instance.CloseUI(typeof(UI_ShopListInfobox));
    }
}
