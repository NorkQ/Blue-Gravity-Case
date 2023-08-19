using UnityEngine;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using DG.Tweening;
 
public class UI_InventoryPanel : MonoBehaviour {
 
    [Title("Refs")]
    [SerializeField, ReadOnly] private Transform m_ExampleRef;
 
    #region Getters and setters
    #endregion
 
    [Button]
    private void setRefs() 
    {
        m_ExampleRef = new GameObject().transform;
    }
 
    private void OnEnable() 
    {
    }
 
    private void OnDisable() 
    {
    }
 
    private void Start() 
    {
    }
 
    private void Update()
    {
    }
}
