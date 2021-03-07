using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    [SerializeField] private GameEventSO _triggerBackToMenu;
    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _resumeGameButton;
    [SerializeField] private Button _backToMenuButton;

    private void Start()
    {
        _pauseButton.onClick.AddListener(OpenPausePanel);
        _resumeGameButton.onClick.AddListener(ClosePausePanel);
        _backToMenuButton.onClick.AddListener(BackToMenu);
    }

    public void OpenPausePanel()
    {
        GameManager.Instance.GamePause();
        _resumeGameButton.gameObject.SetActive(true);
        _backToMenuButton.gameObject.SetActive(true);
        _pauseButton.gameObject.SetActive(false);
    }

    public void ClosePausePanel()
    {
        GameManager.Instance.ResumeGame();
        _resumeGameButton.gameObject.SetActive(false);
        _backToMenuButton.gameObject.SetActive(false);
        _pauseButton.gameObject.SetActive(true);
    }

    public void BackToMenu()
    {
        _triggerBackToMenu.Raise();
        ClosePausePanel();
    }
}
