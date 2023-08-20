using UnityEngine;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using DG.Tweening;
 
public class ShopManager : Singleton<ShopManager> {
 
    [Title("Refs")]

    public delegate void OpenShopAction(SellerData i_SellerData);
    public static event OpenShopAction OnOpenShop;
 
    #region Getters and setters
    #endregion
 
    [Button]
    private void setRefs() 
    {
    }
 
    public void OpenShop(SellerData i_SellerData)
    {
        UIManager.Instance.OpenUI(typeof(UI_ShopPanel));
        OnOpenShop?.Invoke(i_SellerData);
    }
}
