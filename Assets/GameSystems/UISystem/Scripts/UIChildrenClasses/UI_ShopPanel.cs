using UnityEngine;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class UI_ShopPanel : UIBase {
 
    [Title("Refs")]
    [SerializeField, ReadOnly] private Image m_SellerIconImage;
    [SerializeField, ReadOnly] private TMP_Text m_SellerNameText;
    [SerializeField, ReadOnly] private TMP_Text m_SellerQuoteText;
    [SerializeField, ReadOnly] private Transform m_ScrollContentParent;
 
    #region Getters and setters
    #endregion
 
    [Button]
    protected override void setRefs() 
    {
        base.setRefs();
        m_SellerIconImage = transform.FindDeepChild<Image>("Avatar");
        m_SellerNameText = transform.FindDeepChild<TMP_Text>("Seller Name");
        m_SellerQuoteText = transform.FindDeepChild<TMP_Text>("Quote Text");
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        ShopManager.OnOpenShop += initializeShop;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        ShopManager.OnOpenShop -= initializeShop;
    }

    private void initializeShop(SellerData i_SellerData)
    {
        m_SellerIconImage.sprite = i_SellerData.SellerIcon;
        m_SellerNameText.text = i_SellerData.SellerName;
        m_SellerQuoteText.text = i_SellerData.SellerQuote;
    }
}
