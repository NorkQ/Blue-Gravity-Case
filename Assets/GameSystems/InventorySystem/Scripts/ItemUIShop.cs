using UnityEngine;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.EventSystems;
 
public class ItemUIShop : MonoBehaviour {

    [Title("Refs")]
    [SerializeField, ReadOnly] private Image m_Icon;
    [SerializeField, ReadOnly] private Button m_Button;

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
        m_Button = gameObject.GetComponent<Button>();
    }

    public void Initialize(ItemDataBase i_Item)
    {
        m_MyItemData = i_Item;
        m_Icon.sprite = m_MyItemData.ItemIcon;
        m_Button.onClick.AddListener(onClick);
    }

    public void onClick()
    {
        Inventory.Instance.RemoveItem(m_MyItemData);
        OnItemSell?.Invoke(this);
    }
}
