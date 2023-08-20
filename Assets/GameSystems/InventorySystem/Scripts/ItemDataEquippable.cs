using UnityEngine;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using DG.Tweening;

[CreateAssetMenu(menuName = "Pipoza/Scriptable Object/Equippable Item Data", fileName = "New Equippable Item Data")]
public class ItemDataEquippable : ItemDataBase
{
    public eEquippableType EquippableType;
}