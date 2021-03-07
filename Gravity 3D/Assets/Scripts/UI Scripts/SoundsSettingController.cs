using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening; 

public class SoundsSettingController : MonoBehaviour
{
    [Header("Sound Manager")]
    [SerializeField] private SoundManager _soundManager;

    [Header("Sound Settings Button")]
    [SerializeField] private CanvasGroup _soundsCanvas;
    [SerializeField] private RectTransform _soundsPanel;
    [SerializeField] private Vector2 _startPanelTransform;
    [SerializeField] private Vector2 _endPanelTransform;

    [Header("Sound Settings")]
    [SerializeField] private Button _soundButton;
    [SerializeField] private Button _musicButton;
    [SerializeField] private SoundSettingsModel _soundModel;
    [SerializeField] private Image _soundImage;
    [SerializeField] private Image _musicImage;

    [Header("Tweener Settings")]
    [SerializeField] private TweenerUISettings _tweenerUI;

    private bool _soundPanelOpened;

    private void Awake()
    {
        _soundPanelOpened = false;
        _soundButton.onClick.AddListener(ChangeSound);
        _musicButton.onClick.AddListener(ChangeMusic);
    }

    private void Start()
    {
        SetMusicSprite();
        SetSoundSprite();
    }

    public void SoundSettingsButton(Transform transform)
    {
        transform.DOShakePosition(_tweenerUI.SoundShakeTime, _tweenerUI.SoundShakeStrength);
        if (_soundPanelOpened)
        {
            CloseSoundBar();
            _soundPanelOpened = false;
        }
        else
        {
            OpenSoundBar();
            _soundPanelOpened = true;
        }
    }

    private void OpenSoundBar()
    {
        _soundsCanvas.blocksRaycasts = true;
        _soundsCanvas.DOFade(1, _tweenerUI.SoundFadeTime);
        _soundsPanel.DOAnchorPos(_endPanelTransform, _tweenerUI.SoundPanelTime, false);
    }

    private void CloseSoundBar()
    {
        _soundsCanvas.blocksRaycasts = false;
        _soundsCanvas.DOFade(0, _tweenerUI.SoundFadeTime);
        _soundsPanel.DOAnchorPos(_startPanelTransform, _tweenerUI.SoundPanelTime, false);
    }

    private void SetMusicSprite()
    {
        if (_soundManager.IsMusicOn)
        {
            _musicImage.sprite = _soundModel.MusicOn;
        }
        else
        {
            _musicImage.sprite = _soundModel.MusicOff;
        }
    }

    private void SetSoundSprite()
    {
        if (_soundManager.IsSoundOn)
        {
            _soundImage.sprite = _soundModel.SoundOn;
        }
        else
        {
            _soundImage.sprite = _soundModel.SoundOff;
        }
    }

    private void ChangeSound()
    {
        if (_soundManager.IsSoundOn)
        {
            _soundManager.IsSoundOn = false;
        }
        else
        {
            _soundManager.IsSoundOn = true;
        }
        SetSoundSprite();
    }

    private void ChangeMusic()
    {
        if (_soundManager.IsMusicOn)
        {
            _soundManager.IsMusicOn = false;
        }
        else
        {
            _soundManager.IsMusicOn = true;
        }
        SetMusicSprite();
    }
}
