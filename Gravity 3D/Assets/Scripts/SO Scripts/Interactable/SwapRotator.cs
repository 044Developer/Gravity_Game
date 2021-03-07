using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Interactable/Swap Rotator")]
public class SwapRotator : PickUpInteractable
{
    public override void Apply()
    {
        InteractableEvent.Raise();
    }
}
