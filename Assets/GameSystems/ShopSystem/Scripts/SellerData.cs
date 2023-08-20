using UnityEngine;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using DG.Tweening;

// Differen sellers have different items, avatar and quote
[CreateAssetMenu(menuName = "Pipoza/Scriptable Object/Seller Data", fileName = "New Seller Data")]
public class SellerData : ScriptableObject {

    [Title("Basic Data")]
    [PreviewField] public Sprite SellerIcon;
    public string SellerName;

    [TextArea] public string SellerQuote;

    public ItemDataBase[] SellerItems;
}
