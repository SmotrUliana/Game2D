using UnityEngine;
using UnityEngine.UI;

public class Audio : MonoBehaviour
{
    [SerializeField]
    private AudioSource _audioSource;
    [SerializeField]
    private AudioClip _coinSound;
    [SerializeField]
    private Toggle _toggle;

    private bool _enabled;

    private void Awake()
    {
        _enabled = PlayerPrefs.GetInt("Sound") == 1;
        _toggle.SetIsOnWithoutNotify(_enabled);
        _toggle.onValueChanged.AddListener(UpdateState);
        UpdateState(_enabled);
    }

    public void PlayCoinSound()
    {
        if(_enabled)
            _audioSource.PlayOneShot(_coinSound);
    }
    
    private void UpdateState(bool value)
    {
        _enabled = value;
        if(_enabled)
            _audioSource.Play();
        else
            _audioSource.Pause();
        
        PlayerPrefs.SetInt("Sound", value ? 1 : 0);
    }
}