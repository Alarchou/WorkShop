using System;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Listens for changes in a SO_FloatValue and invokes a UnityEvent when the value changes.
/// </summary>
public class FloatEventListener : MonoBehaviour
{
    [SerializeField] private SO_FloatValue floatValue;
    [SerializeField] private UnityEvent<float> callback = new();


    private void OnEnable()
    {
        floatValue.OnValueChanged += HandleValueChanged;
    }

    private void OnDisable()
    {
        floatValue.OnValueChanged -= HandleValueChanged;
    }

    private void HandleValueChanged(float newValue)
    {
        callback?.Invoke(newValue);
    }
}
