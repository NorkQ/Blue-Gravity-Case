using UnityEngine;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using DG.Tweening;
 
public class ItemUseEvents : MonoBehaviour {

    [Title("Refs")]

    #region Getters and setters
    #endregion
 
    [Button]
    private void setRefs() 
    {
    }
 
    private void OnEnable() 
    {
        InventorySlot.OnItemUse += onItemUse;
    }
 
    private void OnDisable() 
    {
        InventorySlot.OnItemUse -= onItemUse;
    }

    // When we click on the items in inventory panel, this method will run.
    private void onItemUse(InventorySlot i_InventorySlot, ItemDataBase i_ItemData)
    {
        // Play item use sound effect like equip, eat etc.
        AudioManager.Instance.PlaySFX(i_ItemData.UseSoundEffect);

        // If clicked an equipment item
        if(i_ItemData is ItemDataEquippable)
        {
            // If player clicked an inventory slot, we'll unequip it.
            if(UIManager.Instance.FindEquipmentSlotByType((i_ItemData as ItemDataEquippable).EquippableType) == i_InventorySlot)
            {
                Inventory.Instance.UnequipItem(i_ItemData);
            }
            // If player didn't click an equipment slot (clicked an inventory slot), we'll unequip current item and equip this.
            else
            {
                Inventory.Instance.EquipItem(i_ItemData);
            }
        }
        // If clicked a non-equipment item
        else
        {
            Inventory.Instance.RemoveItem(i_ItemData);
        }
    }
}
