using UnityEngine;
using System.Collections;
using Sirenix.OdinInspector;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
using System;
 
public class UIManager : Singleton<UIManager> {
 
    [Title("Refs")]
    [SerializeField, ReadOnly] private Canvas m_Canvas;
    [SerializeField, ReadOnly] private EquipmentSlot[] m_EquipmentSlots;

    public delegate void UIOpenAction(string i_Name);
    public static event UIOpenAction OnUIOpen;

    public delegate void UIOpenAtPositionAction(string i_Name, Vector2 i_Position);
    public static event UIOpenAtPositionAction OnUIOpenAtPosition;

    public delegate void UICloseAction(string i_Name);
    public static event UICloseAction OnUIClose;

    #region Getters and setters
    #endregion

    [Button]
    private void setRefs() 
    {
        m_Canvas = FindObjectOfType<Canvas>();
        m_EquipmentSlots = FindObjectsOfType<EquipmentSlot>();
    }

    private void OnEnable()
    {
    }

    private void OnDisable()
    {
    }

    private void Start()
    {
        UIBase[] panels = FindObjectsOfType<UIBase>(true);
        foreach(UIBase ui in panels)
        {
            ui.gameObject.SetActive(true);
        }
    }

    public void OpenUI(Type i_Panel)
    {
        OnUIOpen?.Invoke(i_Panel.Name);
    }

    public void CloseUI(Type i_Panel)
    {
        OnUIClose?.Invoke(i_Panel.Name);
    }

    public void OpenUIWorldPosition(Type i_Panel, Vector3 i_Position, Vector2 i_ScreenOffset)
    {
        Vector2 finalPosition = worldToUIPosition(i_Position) + i_ScreenOffset;
        OnUIOpenAtPosition?.Invoke(i_Panel.Name, finalPosition);
    }

    public void OpenUIPosition(Type i_Panel, Vector2 i_Position)
    {
        OnUIOpenAtPosition?.Invoke(i_Panel.Name, i_Position);
    }

    private Vector2 worldToUIPosition(Vector3 i_TargetPos)
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(i_TargetPos);
        float h = Screen.height;
        float w = Screen.width;
        float x = screenPos.x - (w / 2);
        float y = screenPos.y - (h / 2);
        float s = m_Canvas.scaleFactor;
        return new Vector2(x, y) / s;
    }

    #region Additional methods for this project
    public EquipmentSlot FindEquipmentSlotByType(eEquippableType i_EquipmentType)
    {
        foreach (EquipmentSlot slot in m_EquipmentSlots)
        {
            if (slot.EquipmentType == i_EquipmentType)
            {
                return slot;
            }
        }

        return null;
    }
    #endregion
}
