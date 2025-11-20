using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Listens for a specific game event and invokes a callback when the event is triggered.
/// </summary>
public class GameEventListener : MonoBehaviour
{
    [SerializeField] private SO_GameEvent gameEvent;
    [SerializeField] private UnityEvent callback;

    private void OnEnable()
    {
        if(gameEvent)
            gameEvent.RegisterListener(callback);
    }

    private void OnDisable()
    {
        if(gameEvent)
            gameEvent.RemoveListener(callback);
    }
}
