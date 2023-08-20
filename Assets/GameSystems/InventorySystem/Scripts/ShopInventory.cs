using UnityEngine;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using DG.Tweening;
 
public class ShopInventory : MonoBehaviour {
 
    [Title("Refs")]
    [SerializeField, ReadOnly] private Transform m_ScrollContent;

    #region Getters and setters
    private InventorySystemConfig m_InventorySystemConfig => InventorySystemConfig.Instance;
    #endregion
 
    [Button]
    private void setRefs() 
    {
        m_ScrollContent = transform.FindDeepChild("Container");
    }
 
    private void OnEnable() 
    {
        ItemUIShop.OnItemSell += (ItemUIShop i_ItemUIShop) => refresh();
        ShopUIListElement.OnItemBuy += (ShopUIListElement i_ItemUIShop) => refresh(); 
    }
 
    private void OnDisable() 
    {
        ItemUIShop.OnItemSell -= (ItemUIShop i_ItemUIShop) => refresh();
        ShopUIListElement.OnItemBuy -= (ShopUIListElement i_ItemUIShop) => refresh();
    }
 
    private void initialize()
    {
        ItemUIShop[] oldItems = gameObject.GetComponentsInChildren<ItemUIShop>();

        foreach(ItemUIShop item in oldItems)
        {
            Destroy(item.gameObject);
        }

        foreach(ItemDataBase itemData in Inventory.Instance.Items)
        {
            ItemUIShop shopUIItem = Instantiate(m_InventorySystemConfig.ItemUIShopPrefab, m_ScrollContent);
            shopUIItem.Initialize(itemData);
        }
    }

    private void refresh()
    {
        initialize();
    }
}
