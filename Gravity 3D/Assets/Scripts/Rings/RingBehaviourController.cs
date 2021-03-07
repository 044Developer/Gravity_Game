using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingBehaviourController : MonoBehaviour
{
    public List<RingRotationController> RingControllers;

    public void SetNewState(GameState state)
    {
        foreach (var ring in RingControllers)
        {
            ring.CurrentState = state;
        }
    }
}
