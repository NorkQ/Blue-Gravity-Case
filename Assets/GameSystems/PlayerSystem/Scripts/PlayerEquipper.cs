using UnityEngine;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using DG.Tweening;
 
public class PlayerEquipper : MonoBehaviour {
 
    [Title("Manual Refs")]
    [SerializeField] private SpriteRenderer m_Head;
    [SerializeField] private SpriteRenderer m_Body;
    [SerializeField] private SpriteRenderer m_Legs;

    #region Getters and setters
    private PlayerSystemConfig m_PlayerSystemConfig => PlayerSystemConfig.Instance;
    #endregion
 
    [Button]
    private void setRefs() 
    {
    }
 
    private void OnEnable() 
    {
        Inventory.OnEquipItem += onEquipItem;
        Inventory.OnUnequipItem += onUnequipItem;
    }
 
    private void OnDisable() 
    {
        Inventory.OnEquipItem -= onEquipItem;
        Inventory.OnUnequipItem -= onUnequipItem;
    }
 
    private void Start() 
    {
    }

    // Change character sprites to target item sprite by item type (head, body, legs)
    private void onEquipItem(ItemDataEquippable i_ItemData)
    {
        switch (i_ItemData.EquippableType)
        {
            case eEquippableType.Head:
                m_Head.sprite = i_ItemData.EquipmentSprite;
                break;
            case eEquippableType.Body:
                m_Body.sprite = i_ItemData.EquipmentSprite;
                break;
            case eEquippableType.Legs:
                m_Legs.sprite = i_ItemData.EquipmentSprite;
                break;
        }
    }

    // Change character sprites to default by item type
    private void onUnequipItem(ItemDataEquippable i_ItemData)
    {
        switch (i_ItemData.EquippableType)
        {
            case eEquippableType.Head:
                m_Head.sprite = m_PlayerSystemConfig.DefaultHead;
                break;
            case eEquippableType.Body:
                m_Body.sprite = m_PlayerSystemConfig.DefaultBody;
                break;
            case eEquippableType.Legs:
                m_Legs.sprite = m_PlayerSystemConfig.DefaultLegs;
                break;
        }
    }
}
