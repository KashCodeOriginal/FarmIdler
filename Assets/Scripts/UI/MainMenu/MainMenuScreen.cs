using System;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScreen : MonoBehaviour
{
    public event Action OnPlayButtonClicked;

    [SerializeField] private Button _playButton;

    private void Start()
    {
        _playButton.onClick.AddListener(PlayButtonClick);
    }

    private void PlayButtonClick()
    {
        OnPlayButtonClicked?.Invoke();
    }
}
