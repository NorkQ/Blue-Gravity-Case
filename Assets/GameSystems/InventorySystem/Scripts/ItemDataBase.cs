using UnityEngine;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using DG.Tweening;

[CreateAssetMenu(menuName = "Pipoza/Scriptable Object/Item Data", fileName = "New Item Data")]
public class ItemDataBase : ScriptableObject
{
    [Title("Basic Data")]
    [PreviewField] public Sprite ItemIcon;

    public string ItemName;
    public int ItemPrice;

    [TextArea] public string ItemDescription;

    public AudioClip UseSoundEffect;
}