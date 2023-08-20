using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using DG.Tweening;

public class Inventory : Singleton<Inventory> {

    [Title("Refs")]

    public List<ItemDataBase> m_Items = new List<ItemDataBase>();
    public List<ItemDataBase> m_Equipments = new List<ItemDataBase>();
    public List<ItemDataBase> m_AllItems = new List<ItemDataBase>();

    #region Getters and setters
    private InventorySystemConfig m_InventorySystemConfig => InventorySystemConfig.Instance;
    public List<ItemDataBase> Items => m_Items;
    public List<ItemDataBase> Equipments => m_Equipments;
    public List<ItemDataBase> AllItems => getAllItems();
    #endregion
 
    [Button]
    private void setRefs() 
    {
    }
    
    [Button]
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

    public bool CheckThisItemInInventory(ItemDataBase i_Item)
    {
        return m_Items.Contains(i_Item) || m_Equipments.Contains(i_Item);
    }

    private List<ItemDataBase> getAllItems()
    {
        m_AllItems.Clear();
        m_AllItems.AddRange(m_Items);
        m_AllItems.AddRange(m_Equipments);

        return m_AllItems;
    }
}
