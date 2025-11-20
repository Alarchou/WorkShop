using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Game Event", menuName = "Scriptables/Game Event")]
public class SO_GameEvent : ScriptableObject
{
    private List<UnityEvent> callbacks = new();
    public void RegisterListener(UnityEvent unityEvent)
    {
        callbacks.Add(unityEvent);
    }

    public void RemoveListener(UnityEvent unityEvent)
    {
        callbacks.Remove(unityEvent);
    }

    public void Raise()
    {
        Debug.Log($"Game Event {name} Raised");
        for (int i = 0; i < callbacks.Count; i++)
        {
            callbacks[i]?.Invoke();
        }
    }
}
