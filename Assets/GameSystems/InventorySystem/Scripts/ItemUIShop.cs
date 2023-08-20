using UnityEngine;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.EventSystems;
 
public class ItemUIShop : MonoBehaviour, IPointerClickHandler{

    [Title("Refs")]
    [SerializeField, ReadOnly] private Image m_Icon;

    private ItemDataBase m_MyItemData;

    public delegate void ItemSellAction(ItemUIShop i_ItemUIShop);
    public static event ItemSellAction OnItemSell;

    #region Getters and setters
    public ItemDataBase MyItemData => m_MyItemData;
    #endregion

    [Button]
    private void setRefs()
    {
        m_Icon = transform.FindDeepChild<Image>("Item Icon");
    }

    public void Initialize(ItemDataBase i_Item)
    {
        m_MyItemData = i_Item;
        m_Icon.sprite = m_MyItemData.ItemIcon;
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        Inventory.Instance.RemoveItem(m_MyItemData);
        OnItemSell?.Invoke(this);
    }
}
