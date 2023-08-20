using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using DG.Tweening;

public class Inventory : Singleton<Inventory> {

    [Title("Refs")]

    // Unequipped items
    private List<ItemDataBase> m_Items = new List<ItemDataBase>();

    // Equipped items
    private List<ItemDataBase> m_Equipments = new List<ItemDataBase>();

    // All items
    private List<ItemDataBase> m_AllItems = new List<ItemDataBase>();

    public delegate void ItemEquipAction(ItemDataEquippable i_ItemDataEquippable);
    public static event ItemEquipAction OnEquipItem;

    public delegate void ItemUnequipAction(ItemDataEquippable i_ItemDataEquippable);
    public static event ItemUnequipAction OnUnequipItem;

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
    
    public void AddItem(ItemDataBase i_Item)
    {
        // We can add item if max size not reached
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

        // If equipment slot is filled, we'll unequip current item. Than we can equip new item this way.
        EquipmentSlot equipmentSlot = UIManager.Instance.FindEquipmentSlotByType((i_Item as ItemDataEquippable).EquippableType);
        if (equipmentSlot.SlotStatus == eSlotStatus.Filled)
        {
            UnequipItem(equipmentSlot.MyItemData);
        }

        m_Items.Remove(i_Item);
        m_Equipments.Add(i_Item);

        OnEquipItem?.Invoke(i_Item as ItemDataEquippable);

    }

    public void UnequipItem(ItemDataBase i_Item)
    {
        m_Equipments.Remove(i_Item);
        m_Items.Add(i_Item);

        OnUnequipItem?.Invoke(i_Item as ItemDataEquippable);
    }

    public bool CheckThisItemInInventory(ItemDataBase i_Item)
    {
        return m_Items.Contains(i_Item) || m_Equipments.Contains(i_Item);
    }

    public bool CheckIsEquipped(ItemDataBase i_Item)
    {
        return m_Equipments.Contains(i_Item);
    }

    private List<ItemDataBase> getAllItems()
    {
        m_AllItems.Clear();
        m_AllItems.AddRange(m_Items);
        m_AllItems.AddRange(m_Equipments);

        return m_AllItems;
    }
}
