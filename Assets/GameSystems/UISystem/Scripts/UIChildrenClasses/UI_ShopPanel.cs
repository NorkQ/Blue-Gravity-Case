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
    [SerializeField, ReadOnly] private Button m_CloseButton;

    #region Getters and setters
    private ShopSystemConfig m_ShopSystemConfig => ShopSystemConfig.Instance;
    #endregion
 
    [Button]
    protected override void setRefs() 
    {
        base.setRefs();
        m_SellerIconImage = transform.FindDeepChild<Image>("Avatar");
        m_SellerNameText = transform.FindDeepChild<TMP_Text>("Seller Name");
        m_SellerQuoteText = transform.FindDeepChild<TMP_Text>("Quote Text");
        m_ScrollContentParent = transform.FindDeepChild("Container");
        m_CloseButton = transform.FindDeepChild<Button>("Close Button");
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        ShopManager.OnOpenShop += initializeShop;
        m_CloseButton.onClick.AddListener(() => UIManager.Instance.OpenUI(typeof(UI_GamePanel)));
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        ShopManager.OnOpenShop -= initializeShop;
        m_CloseButton.onClick.RemoveAllListeners();
    }

    private void initializeShop(SellerData i_SellerData)
    {
        m_SellerIconImage.sprite = i_SellerData.SellerIcon;
        m_SellerNameText.text = i_SellerData.SellerName;
        m_SellerQuoteText.text = i_SellerData.SellerQuote;

        ShopUIListElement[] shopUIElements = gameObject.GetComponentsInChildren<ShopUIListElement>();

        foreach(ShopUIListElement shopUIElement in shopUIElements)
        {
            Destroy(shopUIElement.gameObject);
        }

        foreach(ItemDataBase item in i_SellerData.SellerItems)
        {
            ShopUIListElement uiItem = Instantiate(m_ShopSystemConfig.ItemElementPrefab, m_ScrollContentParent);
            uiItem.Initialize(item);
        }
    }
}
