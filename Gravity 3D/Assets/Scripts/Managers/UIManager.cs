using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Controllers")]
    [SerializeField] private PlayerCustomizationController _customizationController;
    [SerializeField] private MainPanelController _mainPanelController;
    [SerializeField] private SoundsSettingController _soundSettingsController;
    [SerializeField] private PauseController _pauseController;

    [Header("Buttons")]
    [SerializeField] private Button _customizationButton;
    [SerializeField] private Button _closeCustomizationButton;
    [SerializeField] private Button _startGameButton;
    [SerializeField] private Button _soundSettingsButton;

    private void Awake()
    {
        InitializeButtons();
    }

    private void InitializeButtons()
    {
        _customizationButton.onClick.AddListener(() => _customizationController.OpenCustomizationPanel());
        _customizationButton.onClick.AddListener(() => _mainPanelController.ClosePanel(_startGameButton.transform));
        _closeCustomizationButton.onClick.AddListener(() => _customizationController.CloseCustomizationPanel());
        _closeCustomizationButton.onClick.AddListener(() => _mainPanelController.OpenPanel());
        _startGameButton.onClick.AddListener(() => _mainPanelController.ClosePanel(_startGameButton.transform));
        _startGameButton.onClick.AddListener(() => GameManager.Instance.StartGame());
        _soundSettingsButton.onClick.AddListener(() => _soundSettingsController.SoundSettingsButton(_soundSettingsButton.transform));
    }
}
