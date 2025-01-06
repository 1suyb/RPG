using System;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(menuName = "Events/Sound Event Listener")]
public class SoundEventListenrSO : ScriptableObject
{
    [SerializeField] private SFXKeyValuePair[] _sfxClips;
    [SerializeField] private BGMKeyValuePair[] _sgmClips;
    public Dictionary<SFXType, AudioClip> SfxDict;
    public Dictionary<BGMType, AudioClip> BgmDict;
    
    public event Action<AudioClip, Vector3> OnSfxEventRaised;
    public event Action<AudioClip> OnBgmEventRaised;
    
    public event Action<float> OnBGMVolumeChanged;
    private float _sfxVolume;
    public float SFXVolme => _sfxVolume;


    public void MakeDict()
    {
        SfxDict = new Dictionary<SFXType, AudioClip>();
        BgmDict = new Dictionary<BGMType, AudioClip>();
        
        foreach (var pair in _sfxClips)
        {
            SfxDict[pair.Key] = pair.Value;
        }

        foreach (var pair in BgmDict)
        {
            BgmDict[pair.Key] = pair.Value;
        }
    }
    
    public void SFXEvent(SFXType soundType, Vector3 position)
    {
        OnSfxEventRaised?.Invoke(SfxDict[soundType], position);
    }
    public void BGMEvent(BGMType soundType)
    {
        OnBgmEventRaised?.Invoke(BgmDict[soundType]);;
    }
    public void BGMVolumeChanged(float volume)
    {
        OnBGMVolumeChanged?.Invoke(volume);
    }
    public void SFXVolumeChanged(float volume)
    {
        _sfxVolume = volume;
    }
}

