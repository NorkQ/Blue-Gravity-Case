using UnityEngine;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
 
public class UI_WarningPanel : UIBase {
 
    [Title("Refs")]
    [SerializeField, ReadOnly] private Button m_CloseButton;
    [SerializeField, ReadOnly] private TMP_Text m_WarningText;
 
    #region Getters and setters
    #endregion
 
    [Button]
    protected override void setRefs() 
    {
        base.setRefs();

        m_CloseButton = transform.FindDeepChild<Button>("Close Button");
        m_WarningText = transform.FindDeepChild<TMP_Text>("Warning Text");
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        m_CloseButton.onClick.AddListener(close);

        UIManager.OnOpenWarning += update;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        UIManager.OnOpenWarning -= update;
    }

    private void update(string i_Warning)
    {
        m_WarningText.text = i_Warning;
    }
}
