using UnityEngine;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using DG.Tweening;
using UnityEngine.UI;
 
// Item cell in the inventory panel. Not slot
public class ItemUI : MonoBehaviour {
 
    [Title("Refs")]
    [SerializeField, ReadOnly] private Image m_Icon;

    private ItemDataBase m_MyItemData;

    #region Getters and setters
    public ItemDataBase MyItemData => m_MyItemData;
    #endregion
 
    [Button]
    private void setRefs() 
    {
        m_Icon = gameObject.GetComponent<Image>();
    }

    public void Initialize(ItemDataBase i_Item)
    {
        m_MyItemData = i_Item;
        m_Icon.sprite = m_MyItemData.ItemIcon;
    }
}
