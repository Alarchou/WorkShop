using System;
using UnityEngine;

/// <summary>
/// Represents a floating-point value that can be used to store and manage a single numeric value in Unity.
/// </summary>
/// <remarks>This class is typically used in Unity projects to hold a float value that can be shared or modified
/// at runtime. It can be used to store configuration values, runtime data, or other numeric information.</remarks>
/// 
[CreateAssetMenu(fileName = "New Float Value", menuName = "Scriptables/FloatValue")]
public class SO_FloatValue : ScriptableObject
{
    public float Value;
    public event Action<float> OnValueChanged;

    public void Set(float newValue)
    {
        Debug.Log($"Setting Float Value from {Value} to {newValue}");
        if (Value != newValue)
        {
            Value = newValue;
            OnValueChanged?.Invoke(newValue);
        }
    }
}
