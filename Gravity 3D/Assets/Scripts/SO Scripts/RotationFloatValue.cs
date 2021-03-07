using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Rings/Rotation/SpeedValue")]
public class RotationFloatValue : ScriptableObject
{
    public float RotationIncreaseValue;
    public float RotationDecreaseValue;
    public float GameRotationSpeed;
    public float NormalGameSpeed;
    public float MenuRotationSpeed;
    public float FastRotationSpeed;

    public void Initialize(RingRotationController controller)
    {
        controller.GameRotationSpeed = GameRotationSpeed;
        controller.SpeedIncreaseMultiplier = RotationIncreaseValue;
        controller.SpeedDecreaseMultiplier = RotationDecreaseValue;
    }

    private void OnEnable()
    {
        GameRotationSpeed = NormalGameSpeed;
    }
}
