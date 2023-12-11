using System;
using UnityEngine;
using UnityEngine.UI;

public class Pauser : MonoBehaviour
{
    [SerializeField]
    private PlayerController _player;
    [SerializeField]
    private Button _pauseButton;
    [SerializeField]
    private GameObject _window;
    
    public void Pause()
    {
        _player.Pause();
        _window.SetActive(true);
        Time.timeScale = 0;
        _pauseButton.interactable = false;
    }

    public void Resume()
    {
        _player.Resume();
        Time.timeScale = 1;
        _window.SetActive(false);
        _pauseButton.interactable = true;
    }
}