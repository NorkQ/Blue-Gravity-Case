using UnityEngine;
using System.Collections;
using Sirenix.OdinInspector;
using DG.Tweening;
using UnityEngine.UI;
 
public abstract class UIBase : MonoBehaviour {
 
    [Title("Refs")]
    [SerializeField, ReadOnly] private string m_UIName;
    [SerializeField, ReadOnly] private Image m_ImageGraphic;
    [SerializeField, ReadOnly] private RectTransform m_RectTransform;

    [Title("Manual Refs")]
    [SerializeField] private eUIType m_UIType;
    [SerializeField] private bool m_CloseOnStart;
    [SerializeField] private float m_WaitForCloseDuration;

    private bool m_IsSubscribed;
    private bool m_IsClosedOnStart;

    #region UI Open Events
    public delegate void UIOpenAction(string i_Name);
    public static event UIOpenAction OnUIOpened;

    public delegate void PrimaryUIOpenAction(string i_Name);
    public static event PrimaryUIOpenAction OnPrimaryUIOpened;

    public delegate void SecondaryUIOpenAction(string i_Name);
    public static event SecondaryUIOpenAction OnSecondaryUIOpened;

    public delegate void TertiaryUIOpenAction(string i_Name);
    public static event TertiaryUIOpenAction OnTertiaryUIOpened;
    #endregion

    #region UI Close Events
    public delegate void UICloseAction(string i_Name);
    public static event UICloseAction OnUIClosed;

    public delegate void PrimaryUICloseAction(string i_Name);
    public static event PrimaryUICloseAction OnPrimaryUIClosed;

    public delegate void SecondaryUICloseAction(string i_Name);
    public static event SecondaryUICloseAction OnSecondaryUIClosed;

    public delegate void TertiaryUICloseAction(string i_Name);
    public static event TertiaryUICloseAction OnTertiaryUIClosed;
    #endregion

    #region Getters and setters
    #endregion

    [Button]
    protected virtual void setRefs() 
    {
        m_UIName = this.GetType().Name;
        m_ImageGraphic = gameObject.GetComponent<Image>();
        m_RectTransform = gameObject.GetComponent<RectTransform>();
    }

    protected virtual void init()
    {
        m_IsSubscribed = true;
        if (m_CloseOnStart && !m_IsClosedOnStart) DOVirtual.DelayedCall(m_WaitForCloseDuration, close);
    }
 
    protected virtual void OnEnable() 
    {
        UIBase.OnPrimaryUIOpened += checkForPrimaryUIOpened;
        UIManager.OnUIClose += checkForUIManagerClose;

        if (!m_IsSubscribed)
        {
            UIManager.OnUIOpen += checkForUIManagerOpen;
            UIManager.OnUIOpenAtPosition += checkForUIManagerOpenAtPosition;
        }

        init();
    }
 
    protected virtual void OnDisable() 
    {
        UIBase.OnPrimaryUIOpened -= checkForPrimaryUIOpened;
        UIManager.OnUIClose -= checkForUIManagerClose;
    }

    protected virtual void Start()
    {
        
    }

    [Button]
    protected virtual void open()
    {
        gameObject.SetActive(true);

        OnUIOpened?.Invoke(m_UIName);
        callOpenEventByType();
    }

    [Button]
    protected virtual void close()
    {
        gameObject.SetActive(false);
        m_IsClosedOnStart = true;

        OnUIClosed?.Invoke(m_UIName);
        callCloseEventByType();
    }
 
    private void callOpenEventByType()
    {
        switch (m_UIType)
        {
            case eUIType.Primary:
                OnPrimaryUIOpened?.Invoke(m_UIName);
                break;
            case eUIType.Secondary:
                OnSecondaryUIOpened?.Invoke(m_UIName);
                break;
            case eUIType.Tertiary:
                OnTertiaryUIOpened?.Invoke(m_UIName);
                break;
        }
    }

    private void callCloseEventByType()
    {
        switch (m_UIType)
        {
            case eUIType.Primary:
                OnPrimaryUIClosed?.Invoke(m_UIName);
                break;
            case eUIType.Secondary:
                OnSecondaryUIClosed?.Invoke(m_UIName);
                break;
            case eUIType.Tertiary:
                OnTertiaryUIClosed?.Invoke(m_UIName);
                break;
        }
    }

    /* Check if any primary UI opened. If it's not me, then close me. Because there shouldn't be
     * active primary panels more than one.
     */
    protected virtual void checkForPrimaryUIOpened(string i_Name)
    {
        if(i_Name != m_UIName && m_UIType == eUIType.Primary)
        {
            UIManager.Instance.CloseUI(this.GetType());
        }
    }

    protected virtual void checkForUIManagerOpenAtPosition(string i_Name, Vector2 i_Position)
    {
        if (i_Name != m_UIName) return;
        m_RectTransform.anchoredPosition = i_Position;
        open();
    }

    // Check when we call UIManager.Instance.OpenUI() method.
    private void checkForUIManagerOpen(string i_Panel)
    {
        if (i_Panel != m_UIName) return;
        open();
    }

    // Check when we call UIManager.Instance.CloseUI() method.
    private void checkForUIManagerClose(string i_Panel)
    {
        if (i_Panel != m_UIName) return;
        close();
    }
}
