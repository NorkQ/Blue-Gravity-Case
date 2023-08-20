using UnityEngine;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using DG.Tweening;
 
public class Shop : MonoBehaviour {

    [Title("Manual Refs")]
    [SerializeField] private SellerData m_SellerData;
 
    #region Getters and setters
    #endregion
 
    [Button]
    private void setRefs() 
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ShopManager.Instance.OpenShop(m_SellerData);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        UIManager.Instance.CloseUI(typeof(UI_ShopPanel));
    }
}
