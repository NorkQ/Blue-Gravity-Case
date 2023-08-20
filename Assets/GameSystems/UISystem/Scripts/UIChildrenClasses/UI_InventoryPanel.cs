using UnityEngine;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using DG.Tweening;
using UnityEngine.UI;
using System.Linq;
 
public class UI_InventoryPanel : UIBase {

    [Title("Refs")]
    [SerializeField, ReadOnly] private Button m_CloseButton;
    [SerializeField, ReadOnly] private InventorySlot[] m_AllInventorySlots; // Includes equippables
    [SerializeField, ReadOnly] private InventorySlot[] m_InventorySlots;
    [SerializeField, ReadOnly] private EquipmentSlot[] m_EquipmentSlots;

    #region Getters and setters
    private InventorySystemConfig m_InventorySystemConfig => InventorySystemConfig.Instance;
    #endregion

    [Button]
    protected override void setRefs()
    {
        base.setRefs();
        m_CloseButton = transform.FindDeepChild<Button>("Close Button");

        m_AllInventorySlots = gameObject.GetComponentsInChildren<InventorySlot>();
        m_InventorySlots = m_AllInventorySlots.Where(x => !(x is EquipmentSlot)).ToArray();
        m_EquipmentSlots = gameObject.GetComponentsInChildren<EquipmentSlot>();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        m_CloseButton.onClick.AddListener(close);
        updateInventoryPanel();
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        m_CloseButton.onClick.RemoveAllListeners();
    }

    private void updateInventoryPanel()
    {
        // All items that we have in inventory panel
        ItemDataBase[] allItemsInUI = m_AllInventorySlots.Where(x => x.SlotStatus == eSlotStatus.Filled).Select(x => x.MyItemData).ToArray();

        List<ItemDataBase> allItemsInUIList = new List<ItemDataBase>(allItemsInUI);
        List<ItemDataBase> allItemsInInventory = new List<ItemDataBase>(Inventory.Instance.AllItems);

        #region In Inventory But Not In UI
        // All items that we have in inventory but not in UI. Inventory panel must be updated to see our new items in the UI.
        List<ItemDataBase> inInventoryButNotInUI = new List<ItemDataBase>();
        foreach (ItemDataBase itemData in Inventory.Instance.AllItems)
        {
            if (allItemsInUIList.Contains(itemData))
            {
                allItemsInUIList.Remove(itemData);
            }
            else
            {
                inInventoryButNotInUI.Add(itemData);
            }
        }
        #endregion

        // All items that we have in UI but not in inventory. They must be removed from the UI.
        #region Not In Inventory But In UI
        List<ItemDataBase> notInInventoryButInUI = new List<ItemDataBase>();
        foreach (ItemDataBase itemData in allItemsInUI)
        {
            if (allItemsInInventory.Contains(itemData))
            {
                allItemsInInventory.Remove(itemData);
            }
            else
            {
                notInInventoryButInUI.Add(itemData);
            }
        }
        #endregion

        foreach (ItemDataBase itemData in notInInventoryButInUI)
        {
            foreach(InventorySlot slot in m_AllInventorySlots)
            {
                if (itemData == slot.MyItemData)
                {
                    slot.RemoveMyItem();
                    break;
                }
            }
        }

        foreach(ItemDataBase itemData in inInventoryButNotInUI)
        {
            ItemUI itemUI = Instantiate(m_InventorySystemConfig.ItemUIPrefab);
            itemUI.Initialize(itemData);
            getEmptyInventorySlot().SetMyItem(itemUI);
        }
    }

    private InventorySlot getEmptyInventorySlot()
    {
        foreach(InventorySlot slot in m_InventorySlots)
        {
            if (slot.SlotStatus == eSlotStatus.Empty) return slot;
        }

        Debug.Log("return null");
        return null;
    }
}
