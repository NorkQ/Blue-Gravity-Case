using UnityEngine;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using DG.Tweening;
using TMPro;
 
public class Tutorial : MonoBehaviour {
 
    [Title("Refs")]
    [SerializeField, ReadOnly] private TMP_Text m_TutorialText;
 
    #region Getters and setters
    #endregion
 
    [Button]
    private void setRefs() 
    {
        m_TutorialText = transform.FindDeepChild<TMP_Text>("Tutorial Text");
    }

    private void OnEnable()
    {
        // Hide tutorial when player opens inventory
        UIManager.OnOpenInventory += () => m_TutorialText.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        UIManager.OnOpenInventory -= () => m_TutorialText.gameObject.SetActive(false);
    }

    // If tutorial not showed, show it to player.
    private void Awake()
    {
        if(PlayerPrefs.GetInt("IsTutorialShowed") == 0)
        {
            m_TutorialText.gameObject.SetActive(true);
            PlayerPrefs.SetInt("IsTutorialShowed", 1);
        }
    }
}
