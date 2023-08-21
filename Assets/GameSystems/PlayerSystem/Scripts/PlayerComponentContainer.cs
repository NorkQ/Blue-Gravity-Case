using UnityEngine;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using DG.Tweening;
 
public class PlayerComponentContainer : Singleton<PlayerComponentContainer> {

    [Title("Refs")]
    [SerializeField, ReadOnly] private Animator m_PlayerAnimator;
    [SerializeField, ReadOnly] private PlayerMovement m_PlayerMovement;
    [SerializeField, ReadOnly] private PlayerEquipper m_PlayerEquipper;

    #region Getters and setters
    public PlayerMovement PlayerMovement => m_PlayerMovement;
    public PlayerEquipper PlayerEquipper => m_PlayerEquipper;
    public Animator PlayerAnimator => m_PlayerAnimator;
    #endregion

    [Button]
    private void setRefs()
    {
        m_PlayerMovement = gameObject.GetComponent<PlayerMovement>();
        m_PlayerEquipper = gameObject.GetComponent<PlayerEquipper>();
        m_PlayerAnimator = transform.FindDeepChild<Animator>("Player Mesh");
    }
}
