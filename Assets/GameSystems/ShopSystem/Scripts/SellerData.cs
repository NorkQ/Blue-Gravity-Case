using UnityEngine;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using DG.Tweening;

[CreateAssetMenu(menuName = "Pipoza/Scriptable Object/Seller Data", fileName = "New Seller Data")]
public class SellerData : ScriptableObject {

    [Title("Basic Data")]
    [PreviewField] public Sprite SellerIcon;
    public string SellerName;

    [TextArea] public string SellerQuote;

    public ItemDataBase[] SellerItems;
}
