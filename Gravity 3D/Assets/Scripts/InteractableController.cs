using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableController : MonoBehaviour
{
    private const string PlayerTag = "Player";

    [SerializeField] private PickUpInteractable _interactable;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(PlayerTag))
        {
            _interactable.Apply();
            gameObject.SetActive(false);
        }
    }
}
