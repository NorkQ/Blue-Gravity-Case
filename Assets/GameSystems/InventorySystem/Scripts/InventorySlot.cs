using UnityEngine;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using DG.Tweening;
 
public class InventorySlot : MonoBehaviour {
 
    [Title("Refs")]

    private eSlotStatus m_SlotStatus;
    private ItemUI m_MyItem;
    private ItemDataBase m_MyItemData;

    #region Getters and setters
    public eSlotStatus SlotStatus => m_SlotStatus;
    public ItemDataBase MyItemData => m_MyItemData;
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
        Destroy(m_MyItem.gameObject);
        m_MyItem = null;
        m_MyItemData = null;
        m_SlotStatus = eSlotStatus.Empty;
    }
}
