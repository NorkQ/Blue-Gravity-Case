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
        m_CloseButton.onClick.AddListener(() => UIManager.Instance.OpenUI(typeof(UI_GamePanel)));
        updateAll();

        Inventory.OnEquipItem += (ItemDataEquippable i_ItemData) => updateAll();
        Inventory.OnUnequipItem += (ItemDataEquippable i_ItemData) => updateAll();
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        m_CloseButton.onClick.RemoveAllListeners();

        Inventory.OnEquipItem -= (ItemDataEquippable i_ItemData) => updateAll();
        Inventory.OnUnequipItem -= (ItemDataEquippable i_ItemData) => updateAll();
    }

    private void updateAll()
    {
        updateInventoryPanel();
        updateEquipmentPanel();
    }

    private void updateInventoryPanel()
    {
        // All items that we have in inventory panel
        ItemDataBase[] allItemsInUI = m_InventorySlots.Where(x => x.SlotStatus == eSlotStatus.Filled).Select(x => x.MyItemData).ToArray();

        List<ItemDataBase> allItemsInUIList = new List<ItemDataBase>(allItemsInUI);
        List<ItemDataBase> allItemsInInventory = new List<ItemDataBase>(Inventory.Instance.Items);

        #region In Inventory But Not In UI
        // All items that we have in inventory but not in UI. Inventory panel must be updated to see our new items in the UI.
        List<ItemDataBase> inInventoryButNotInUI = new List<ItemDataBase>();
        foreach (ItemDataBase itemData in Inventory.Instance.Items)
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

        #region Instantiate or Destroy Inventory Items
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
        #endregion
    }

    private void updateEquipmentPanel()
    {
        foreach(EquipmentSlot equipmentSlot in m_EquipmentSlots)
        {
            equipmentSlot.RemoveMyItem();
        }

        foreach(ItemDataEquippable itemData in Inventory.Instance.Equipments)
        {
            ItemUI itemUI = Instantiate(m_InventorySystemConfig.ItemUIPrefab);
            itemUI.Initialize(itemData);
            getEquipmentSlotByType(itemData.EquippableType).SetMyItem(itemUI);
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

    private EquipmentSlot getEquipmentSlotByType(eEquippableType i_EquippableType)
    {
        foreach(EquipmentSlot equipmentSlot in m_EquipmentSlots)
        {
            if (equipmentSlot.EquipmentType == i_EquippableType) return equipmentSlot;
        }

        return null;
    }
}
