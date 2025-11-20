using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Basic trigger event component that invokes a UnityEvent when a collider with a specified tag and layer enters the trigger.
/// </summary>
public class TriggerEvent : MonoBehaviour
{
    [SerializeField, Tooltip("Targeted tag of the entering collider")] private string triggerTag = "Untagged";
    [SerializeField, Tooltip("Targeted layer of the entering collider")] private LayerMask layerMask;
    [SerializeField, Tooltip("Event to fire when the trigger is valid")] private UnityEvent triggerEvent = new();
    private void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & layerMask) != 0)
        {
            if (other.CompareTag(triggerTag))
            {
                Debug.Log($"{gameObject.name} triggered by {other.gameObject.name} with tag {triggerTag}");
                triggerEvent.Invoke();
            }
        }
    }
}

