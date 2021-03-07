using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickUpInteractable : ScriptableObject
{
    public GameEventSO InteractableEvent;
    public abstract void Apply();
}
