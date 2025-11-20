using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Int based Unity Events, you can define multiple int values and their associated eventss
/// </summary>
public class IntEvents : MonoBehaviour
{
    [Serializable]
    protected class UnityIntEvents
    {
        public int TargetValue;
        public UnityEvent Event;
    }

    [SerializeField] SO_IntValue intValue;
    [SerializeField] UnityIntEvents[] intEvents;

    private void OnEnable()
    {
        intValue.OnValueChanged += OnIntValueChanged;
    }

    private void OnDisable()
    {
        intValue.OnValueChanged -= OnIntValueChanged;
    }

    private void OnIntValueChanged(int newValue)
    {
        UnityIntEvents targetEvent = intEvents.Where(x => x.TargetValue == newValue).FirstOrDefault();

        if(targetEvent != null)
        {
            targetEvent.Event?.Invoke();
        }
    }
}
