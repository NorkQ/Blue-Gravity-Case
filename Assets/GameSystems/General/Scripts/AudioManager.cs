using UnityEngine;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using DG.Tweening;
 
public class AudioManager : Singleton<AudioManager> {
 
    [Title("Refs")]
    [SerializeField, ReadOnly] private AudioSource[] m_AudioSources;
 
    #region Getters and setters
    #endregion
 
    [Button]
    private void setRefs() 
    {
        m_AudioSources = gameObject.GetComponentsInChildren<AudioSource>();
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
}
