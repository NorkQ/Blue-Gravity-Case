using UnityEngine;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using DG.Tweening;
using System.Linq;
 
public class AudioManager : Singleton<AudioManager> {

    [Title("Refs")]
    [SerializeField, ReadOnly] private AudioSource m_AmbientAudioSource;
    [SerializeField, ReadOnly] private AudioSource[] m_AudioSources;
 
    #region Getters and setters
    #endregion
 
    [Button]
    private void setRefs() 
    {
        // Do not include first audiosource
        m_AudioSources = gameObject.GetComponentsInChildren<AudioSource>().Where(x => x.gameObject != gameObject).ToArray();
        m_AmbientAudioSource = gameObject.GetComponent<AudioSource>();
    }

    private void Start()
    {
        DOVirtual.DelayedCall(0.5f, () => PlayAmbientMusic(GeneralConfig.Instance.InGameAmbientMusic));
    }

    private void OnEnable()
    {
        UIManager.OnUIOpen += playAmbientByPanel;
    }

    private void OnDisable()
    {
        UIManager.OnUIOpen -= playAmbientByPanel;
    }

    // Find an audio source that not in use
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
        if (i_Clip == null) return;
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

    // Decrease previous ambient music's volume smoothly than play new one
    public void PlayAmbientMusic(AudioClip i_Clip)
    {
        m_AmbientAudioSource.DOFade(0, 0.7f).OnComplete(
            () => {
                m_AmbientAudioSource.Stop();
                m_AmbientAudioSource.volume = 1f;
                m_AmbientAudioSource.clip = i_Clip;
                m_AmbientAudioSource.Play();
            });
        
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
