using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/GameEvents")]
public class GameEventSO : ScriptableObject
{
    private List<GameEventListener> listeners; 

    private void OnEnable()
    {
        listeners = new List<GameEventListener>();
    }

    public void Raise()
    {
        foreach (var events in listeners)
        {
            events.OnEventRaised();
        }
    }

    public void RegisterListener(GameEventListener listener) 
    {
        if (!listeners.Contains(listener))
            listeners.Add(listener);
    }
    public void UnregisterListener(GameEventListener listener) 
    {
        if (!listeners.Contains(listener))
            listeners.Remove(listener);
    }
        
}
