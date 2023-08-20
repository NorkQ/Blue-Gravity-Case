using UnityEngine;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
 
public class UI_ShopListInfobox : UIBase {
 
    [Title("Refs")]
    [SerializeField, ReadOnly] private TMP_Text m_InfoText;
    [SerializeField, ReadOnly] private RectTransform m_Transform;
    [SerializeField, ReadOnly] private Camera m_MainCamera;
 
    #region Getters and setters
    #endregion
 
    [Button]
    protected override void setRefs() 
    {
        base.setRefs();

        m_InfoText = transform.FindDeepChild<TMP_Text>("Info Text");
        m_Transform = gameObject.GetComponent<RectTransform>();
        m_MainCamera = Camera.main;
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        UIManager.OnOpenShopInfobox += update;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        UIManager.OnOpenShopInfobox -= update;
    }

    private void Update()
    {
        //m_Transform.position = UIManager.Instance.MousePosToUIPos();
    }

    private void update(string i_Warning)
    {
        m_InfoText.text = i_Warning;
    }
}
