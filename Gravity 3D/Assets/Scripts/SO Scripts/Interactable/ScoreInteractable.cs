using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Interactable/Score Pick Up")]
public class ScoreInteractable : PickUpInteractable
{
    public override void Apply()
    {
        InteractableEvent.Raise();
    }
}
