using UnityEngine;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using DG.Tweening;
using UnityEngine.EventSystems;
 
public class InventorySlot : MonoBehaviour, IPointerClickHandler {
 
    [Title("Refs")]
    
    // To know if slot is empty or has an item
    private eSlotStatus m_SlotStatus;

    // Item cell with an icon. We'll see this in inventory grid.
    private ItemUI m_MyItem;

    // Item data scriptable object, basically
    private ItemDataBase m_MyItemData;

    // This event will work when we click on the item in inventory panel. For example, we'll click on apple and eat it.
    public delegate void ItemUseAction(InventorySlot i_InventorySlot, ItemDataBase m_ItemData);
    public static event ItemUseAction OnItemUse;

    #region Getters and setters
    public eSlotStatus SlotStatus => m_SlotStatus;
    public ItemDataBase MyItemData => m_MyItemData;
    public ItemUI MyItem => m_MyItem;
    #endregion
 
    [Button]
    private void setRefs() 
    {
    }
 
    public virtual void SetMyItem(ItemUI i_ItemUI)
    {
        m_MyItem = i_ItemUI;
        m_MyItemData = m_MyItem.MyItemData;
        m_SlotStatus = eSlotStatus.Filled;

        i_ItemUI.transform.SetParent(transform);
        i_ItemUI.transform.localPosition = Vector3.zero;
    }

    public virtual void RemoveMyItem()
    {
        if (m_SlotStatus == eSlotStatus.Empty) return;
        Destroy(m_MyItem.gameObject);
        m_MyItem = null;
        m_MyItemData = null;
        m_SlotStatus = eSlotStatus.Empty;
    }

    // When click on the slot, we'll use-equip-eat the item.
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (m_SlotStatus == eSlotStatus.Empty) return;

        ItemDataBase myItemData = m_MyItemData;

        RemoveMyItem();
        OnItemUse?.Invoke(this, myItemData);
    }
}
