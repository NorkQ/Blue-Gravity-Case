using UnityEngine;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using DG.Tweening;
 
public class PlayerMovement : MonoBehaviour {
 
    [Title("Refs")]
    [SerializeField, ReadOnly] private Animator m_PlayerAnimator;
    [SerializeField, ReadOnly] private Rigidbody2D m_PlayerRigidbody;

    private Vector2 m_DirectionVector;
    
    private eDirection m_Direction;
    
    private float m_Speed;

    #region Getters and setters
    private PlayerSystemConfig m_PlayerSystemConfig => PlayerSystemConfig.Instance;
    #endregion
 
    [Button]
    private void setRefs() 
    {
        m_PlayerAnimator = transform.FindDeepChild<Animator>("Player Mesh");
        m_PlayerRigidbody = gameObject.GetComponent<Rigidbody2D>();
    }
 
    private void OnEnable() 
    {
    }
 
    private void OnDisable() 
    {
    }
 
    private void Start() 
    {
        m_Direction = eDirection.Up;
    }
 
    private void Update()
    {
        m_DirectionVector.x = Input.GetAxisRaw("Horizontal");
        m_DirectionVector.y = Input.GetAxisRaw("Vertical");
        m_Speed = m_DirectionVector.sqrMagnitude;

        // I added this for new character. See more in github readme about old and new character differences.
        if(m_DirectionVector.x != 0) m_PlayerRigidbody.transform.SetLocalScaleX(m_DirectionVector.x);

        checkDirection();
        updateAnimatorValues();
    }

    private void FixedUpdate()
    {
        m_PlayerRigidbody.velocity = m_DirectionVector.normalized * m_PlayerSystemConfig.MovementSpeed;
    }

    /* These direction calculations were for 4 directional pixel character. I changed the character for some reasons.
     * But you can inspect my codes here anyways. See more description about this decision and old gameplay in github readme.
     */
    private void checkDirection()
    {
        // I am calculating this direction enum because we can use it (can be necessary) later in a different mechanic.

        /* 
         * If player holds horizontal and vertical keys at the same time, 
         * we'll move character this way, but will play only horizontal animations.
         */

        if (m_DirectionVector.x != 0 && m_DirectionVector.y != 0)
        {
            m_Direction = (m_DirectionVector.x > 0) ? eDirection.Right : eDirection.Left;
        }
        else if (m_DirectionVector.x != 0)
        {
            m_Direction = (m_DirectionVector.x > 0) ? eDirection.Right : eDirection.Left;
        }
        else if (m_DirectionVector.y != 0)
        {
            m_Direction = (m_DirectionVector.y > 0) ? eDirection.Up : eDirection.Down;
        }
    }

    private void updateAnimatorValues()
    {
        /*
         * Animator variable names are coming from config files. 
         * Generally I am not using strings and numbers in scripts directly.
         * To see config window: Window/Pipoza/Config Window
         */
        m_PlayerAnimator.SetFloat(m_PlayerSystemConfig.AnimatorHorizontalValueID, m_DirectionVector.x);
        m_PlayerAnimator.SetFloat(m_PlayerSystemConfig.AnimatorVerticalValueID, m_DirectionVector.y);
        m_PlayerAnimator.SetFloat(m_PlayerSystemConfig.AnimatorSpeedValueID, m_Speed);

        // 0: Up, 1: Down, 2: Left, 3: Right
        m_PlayerAnimator.SetFloat(m_PlayerSystemConfig.AnimatorDirectionValueID, (float)((int)m_Direction));
    }
}
