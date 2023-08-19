using UnityEngine;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using DG.Tweening;
 
public class UI_GamePanel : UIBase {
 
    [Title("Refs")]
    [SerializeField, ReadOnly] private Transform m_ExampleRef;
 
    #region Getters and setters
    #endregion
 
    [Button]
    protected override void setRefs() 
    {
        base.setRefs();
        m_ExampleRef = new GameObject().transform;
    }
}
