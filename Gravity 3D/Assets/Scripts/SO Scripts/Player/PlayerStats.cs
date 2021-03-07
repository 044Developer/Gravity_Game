using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/PlayerStats")]
public class PlayerStats : ScriptableObject
{
    public float MinGravityValue;
    public float MaxGravityValue;
    public Vector3 PlayerGameScale;
    public Vector3 PlayerMenuScale;

    public void Init(PlayerController controller)
    {
        controller.MinGravity = MinGravityValue;
        controller.MaxGravity = MaxGravityValue; 
    }
}
