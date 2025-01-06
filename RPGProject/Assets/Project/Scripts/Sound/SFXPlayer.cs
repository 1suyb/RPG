using UnityEngine;

public class SFXPlayer : MonoBehaviour
{
    private AudioSource _source;
    private readonly string _clipEndFunctionName = "End";
    public void Play(AudioClip clip, Vector3 position, float volume)
    {
        this.transform.position = position;
        if (_source == null)
        {
            _source = this.gameObject.GetComponent<AudioSource>();
        }
        _source.volume = volume;
        _source.PlayOneShot(clip);
        Invoke(_clipEndFunctionName, clip.length);
    }

    private void End()
    {
        this.gameObject.SetActive(false);
    }
}
