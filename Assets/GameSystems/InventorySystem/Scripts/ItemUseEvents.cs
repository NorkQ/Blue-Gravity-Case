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

    private void onItemUse(InventorySlot i_InventorySlot, ItemDataBase i_ItemData)
    {
        if (i_ItemData.UseSoundEffect != null) AudioManager.Instance.PlaySFX(i_ItemData.UseSoundEffect);

        if(i_ItemData is ItemDataEquippable)
        {
            // If player clicked inventory slot, we'll unequip it.
            if(UIManager.Instance.FindEquipmentSlotByType((i_ItemData as ItemDataEquippable).EquippableType) == i_InventorySlot)
            {
                Inventory.Instance.UnequipItem(i_ItemData);
            }
            // If not, we'll unequip current item and equip this.
            else
            {
                Inventory.Instance.EquipItem(i_ItemData);
            }
        }
        else
        {
            Inventory.Instance.RemoveItem(i_ItemData);
        }
    }
}
