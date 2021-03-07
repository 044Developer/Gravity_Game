using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[CreateAssetMenu(menuName = "Rings/Rotation/Rotation System")]
public class RotationSystem : ScriptableObject
{
    public void MenuRotation(Transform transform, float menuRotation)
    {
        transform.Rotate(Vector3.up * menuRotation * Time.deltaTime); 
        transform.Rotate(Vector3.forward * menuRotation * Time.deltaTime);
    }

    public void StartGameRotation(Transform transform, float time)
    {
        transform.DORotate(Vector3.zero, time, RotateMode.Fast);
        transform.DOMoveZ(0, time, false);
    }

    public void GameRotation(Transform transform, float gameRotation)
    {
        transform.Rotate(Vector3.forward * gameRotation * Time.deltaTime);
    }

    public void NextLevelRotation(Transform transform, float fastRotation)
    {
        transform.Rotate(Vector3.up * fastRotation * Time.deltaTime);
        transform.Rotate(Vector3.forward * fastRotation * Time.deltaTime);
    }

    public void GameOverRotation(Transform transform, float time)
    {
        transform.DOMoveZ(30, time, false);
    }
}
