using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TweenerSettings/UI Settings")]
public class TweenerUISettings : ScriptableObject
{
    [Header("Sound Tween Settings")]
    public float SoundPanelTime;
    public float SoundFadeTime;
    public float SoundShakeTime;
    public float SoundShakeStrength;

    [Header("Customization Tween Settings")]
    public float CustimizePanelTime;
    public float CustomizationShakeTime;
    public float CustomizationShakeStrength;
    
    [Header("Main Panel Tween Settings")]
    public float MainPanelTime;
    public float MainPanelShakeTime;
    public float MainPanelShakeStrength;
}
