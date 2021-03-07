using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Settings/Interactable Spawn Time")]
public class LevelTimeSettings : ScriptableObject
{
    public float StartingSpawnValue;
    public float ScoreSpawnTime;
    public float MinRotatorSpawn;
    public float MaxRotatorSpawn;
    public float TimeBtwStates;
}
