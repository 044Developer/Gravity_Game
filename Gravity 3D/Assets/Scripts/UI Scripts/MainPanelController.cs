using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPanelController : MonoBehaviour
{
    [SerializeField] private RectTransform _mainPanelTransform;
    [SerializeField] private Vector2 _panelStartTransform;
    [SerializeField] private Vector2 _panelHideTransform;

    [Header("Tweener Time Settings")]
    [SerializeField] private TweenerUISettings _tweenerSettings;

    private void Start()
    {
        _panelStartTransform = _mainPanelTransform.localPosition;
    }

    public void ClosePanel(Transform transform)
    {
        transform.DOShakePosition(_tweenerSettings.MainPanelShakeTime, _tweenerSettings.MainPanelShakeStrength);
        _mainPanelTransform.DOAnchorPos(_panelHideTransform, _tweenerSettings.MainPanelTime);
    }

    public void OpenPanel()
    {
        _mainPanelTransform.DOAnchorPos(_panelStartTransform, _tweenerSettings.MainPanelTime);
    }
}
