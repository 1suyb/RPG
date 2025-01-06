using UnityEngine;

public class AudioSourceFactory<AudioSource>
{
}
namespace Manager
{
    public class SoundManager : MonoBehaviour
    {
        [SerializeField] private SoundEventListenrSO _soundEventListenrSo; 
        
        [SerializeField] private GameObject _sfxPrefab;
        [SerializeField] private GameObject _bgmPrefab;
        private GameObjectFactoryBase<SFXPlayer> _sfxPlayerFactory;
        private AudioSource _bgmSource;
        private float _sfxVolume => _soundEventListenrSo.SFXVolme;
        private void Awake()
        {
            if(_soundEventListenrSo == null)
            {
                _soundEventListenrSo = ResourceManager.Load<SoundEventListenrSO>(ResourcePath.SO.SoundEvent);
            }
            _sfxPlayerFactory = new GameObjectFactoryBase<SFXPlayer>(_sfxPrefab, 0, 50, transform);
            _bgmSource = ResourceManager.Instantiate(_bgmPrefab, this.transform).GetComponent<AudioSource>();
            _bgmSource.loop = true;
        }

        private void OnEnable()
        {
            _soundEventListenrSo.OnSfxEventRaised += PlaySFX;
            _soundEventListenrSo.OnBgmEventRaised += PlayBGM;
            _soundEventListenrSo.OnBGMVolumeChanged += BGMVolumeChanged;
        }

        private void OnDisable()
        {
            _soundEventListenrSo.OnSfxEventRaised -= PlaySFX;
            _soundEventListenrSo.OnBgmEventRaised -= PlayBGM;
            _soundEventListenrSo.OnBGMVolumeChanged -= BGMVolumeChanged;
        }

        private void PlayBGM(AudioClip clip)
        {
            _bgmSource.Stop();
            _bgmSource.clip = clip;
            _bgmSource.Play();
        }
        
        private void PlaySFX(AudioClip clip, Vector3 position)
        {
            SFXPlayer source = _sfxPlayerFactory.Create();
            source.Play(clip, position, _sfxVolume);
        }
        
        private void BGMVolumeChanged(float volume)
        {
            _bgmSource.volume = volume;
        }
        
    }
}

