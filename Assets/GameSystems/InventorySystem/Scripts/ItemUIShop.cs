using UnityEngine;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.EventSystems;
 
// Item cells in the shop. Player can sell items by clicking this graphic.
public class ItemUIShop : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler {

    [Title("Refs")]
    [SerializeField, ReadOnly] private Image m_Icon;
    [SerializeField, ReadOnly] private Button m_Button;

    [Title("Manual Refs")]
    [SerializeField] private AudioClip m_SellSFX;

    private ItemDataBase m_MyItemData;
    private int m_SellinPrice;

    public delegate void ItemSellAction(ItemUIShop i_ItemUIShop);
    public static event ItemSellAction OnItemSell;

    #region Getters and setters
    public ItemDataBase MyItemData => m_MyItemData;
    #endregion

    [Button]
    private void setRefs()
    {
        m_Icon = transform.FindDeepChild<Image>("Item Icon");
        m_Button = gameObject.GetComponent<Button>();
    }

    // Init item icon, events etc.
    public void Initialize(ItemDataBase i_Item)
    {
        m_MyItemData = i_Item;
        m_Icon.sprite = m_MyItemData.ItemIcon;
        m_Button.onClick.AddListener(onClick);
        m_SellinPrice = (int)(m_MyItemData.ItemPrice / Random.Range(1.5f, 2.5f));
    }

    // Sell items
    public void onClick()
    {
        MoneyManager.Instance.EarnMoney(m_SellinPrice);
        Inventory.Instance.RemoveItem(m_MyItemData);
        AudioManager.Instance.PlaySFX(m_SellSFX);
        OnItemSell?.Invoke(this);
    }

    // About little price info panel
    public void OnPointerEnter(PointerEventData eventData)
    {
        UIManager.Instance.OpenSellingPriceInfoPanel("$" + m_SellinPrice.ToString());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        UIManager.Instance.CloseUI(typeof(UI_SellingPriceInfo));
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        UIManager.Instance.CloseUI(typeof(UI_SellingPriceInfo));
    }
}
