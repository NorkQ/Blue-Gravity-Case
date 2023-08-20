using UnityEngine;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using DG.Tweening;
 
public class EquipmentSlot : InventorySlot {

    [Title("Manual Refs")]
    [SerializeField] private eEquippableType m_EquipmentType;

    private bool m_IsEquipped;

    #region Getters and setters
    public eEquippableType EquipmentType => m_EquipmentType;
    public bool IsEquipped => m_IsEquipped;
    #endregion

    public override void SetMyItem(ItemUI i_ItemUI)
    {
        base.SetMyItem(i_ItemUI);
        m_IsEquipped = true;
    }

    public override void RemoveMyItem()
    {
        base.RemoveMyItem();
        m_IsEquipped = false;
    }
}
