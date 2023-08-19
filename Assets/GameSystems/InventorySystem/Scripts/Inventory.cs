using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using DG.Tweening;
 
public class Inventory : Singleton<Inventory> {
 
    [Title("Refs")]
    [SerializeField, ReadOnly] private Transform m_ExampleRef;

    private List<ItemDataBase> m_Items = new List<ItemDataBase>();
    private List<ItemDataBase> m_Equipments = new List<ItemDataBase>();

    #region Getters and setters
    private InventorySystemConfig m_InventorySystemConfig => InventorySystemConfig.Instance;
    #endregion
 
    [Button]
    private void setRefs() 
    {
    }
 
    public void AddItem(ItemDataBase i_Item)
    {
        if (m_Items.Count >= m_InventorySystemConfig.InventorySize) return;
        m_Items.Add(i_Item);
    }

    public void RemoveItem(ItemDataBase i_Item)
    {
        if (m_Items.Contains(i_Item)) m_Items.Remove(i_Item);
        else if (m_Equipments.Contains(i_Item)) m_Equipments.Remove(i_Item);

        m_Items.TrimExcess();
        m_Equipments.TrimExcess();
    }

    public void EquipItem(ItemDataBase i_Item)
    {
        if (!(i_Item is ItemDataEquippable)) return;
    }

    public void UnequipItem(ItemDataBase i_Item)
    {

    }
}
