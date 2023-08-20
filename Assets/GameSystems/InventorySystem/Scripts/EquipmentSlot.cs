using UnityEngine;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using DG.Tweening;
 
public class EquipmentSlot : InventorySlot {

    [Title("Manual Refs")]
    private eEquippableType m_EquipmentType;

    #region Getters and setters
    public eEquippableType EquipmentType => m_EquipmentType;
    #endregion
}
