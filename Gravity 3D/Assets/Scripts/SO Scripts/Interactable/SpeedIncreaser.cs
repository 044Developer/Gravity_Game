using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Interactable/Speed Increase")]
public class SpeedIncreaser : PickUpInteractable
{
    public override void Apply()
    {
        InteractableEvent.Raise();
    }
}
