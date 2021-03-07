using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerCustomizationController : MonoBehaviour
{
    [SerializeField] private RectTransform _customizationPanel;
    [SerializeField] private Vector2 _startPanelTransform;
    [SerializeField] private Vector2 _normalPanelTransform;
    [SerializeField] private Vector2 _endPanelTransform;

    [Header("Tweener Settings")]
    [SerializeField] private TweenerUISettings _tweenerUI;

    public void OpenCustomizationPanel()
    {
        transform.DOShakePosition(_tweenerUI.CustomizationShakeTime, _tweenerUI.CustomizationShakeStrength);
        _customizationPanel.DOAnchorPos(_normalPanelTransform, _tweenerUI.CustimizePanelTime);
    }

    public void CloseCustomizationPanel()
    {
        _customizationPanel.DOAnchorPos(_endPanelTransform, _tweenerUI.CustimizePanelTime).OnComplete(ReturnToStartPosition);
    }


    private void ReturnToStartPosition()
    {
        _customizationPanel.position = _startPanelTransform;
    }
}
