using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Interactable/Coin Interactable")]
public class CoinInteractable : PickUpInteractable
{
    [SerializeField] private GameEventSO _speedDecreaseEvent;
    public override void Apply()
    {
        _speedDecreaseEvent.Raise();
        InteractableEvent.Raise();
    }
}
