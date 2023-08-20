using UnityEngine;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using DG.Tweening;
 
public class AudioManager : Singleton<AudioManager> {

    [Title("Refs")]
    [SerializeField, ReadOnly] private AudioSource m_AmbientAudioSource;
    [SerializeField, ReadOnly] private AudioSource[] m_AudioSources;
 
    #region Getters and setters
    #endregion
 
    [Button]
    private void setRefs() 
    {
        m_AudioSources = gameObject.GetComponentsInChildren<AudioSource>();
        m_AmbientAudioSource = gameObject.GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        UIManager.OnUIOpen += playAmbientByPanel;
    }

    private void OnDisable()
    {
        UIManager.OnUIOpen -= playAmbientByPanel;
    }

    private AudioSource getAudioSourceInIdle()
    {
        foreach(AudioSource source in m_AudioSources)
        {
            if (!source.isPlaying) return source;
        }

        return null;
    }

    public void PlaySFX(AudioClip i_Clip)
    {
        AudioSource sourceToPlay = getAudioSourceInIdle();

        if(sourceToPlay == null)
        {
            AudioSource.PlayClipAtPoint(i_Clip, Camera.main.transform.position);
        }
        else
        {
            sourceToPlay.clip = i_Clip;
            sourceToPlay.Play();
        }
    }

    public void PlayAmbientMusic(AudioClip i_Clip)
    {
        m_AmbientAudioSource.clip = i_Clip;
        m_AmbientAudioSource.Play();
    }

    private void playAmbientByPanel(string i_PanelName)
    {
        switch (i_PanelName)
        {
            case nameof(UI_GamePanel):
                PlayAmbientMusic(GeneralConfig.Instance.InGameAmbientMusic);
                break;
            case nameof(UI_InventoryPanel):
                PlayAmbientMusic(GeneralConfig.Instance.InInventoryAmbientMusic);
                break;
            case nameof(UI_ShopPanel):
                PlayAmbientMusic(GeneralConfig.Instance.InShopAmbientMusic);
                break;
        }
    }
}
