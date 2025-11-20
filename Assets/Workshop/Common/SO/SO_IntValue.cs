using System;
using UnityEngine;

/// <summary>
/// Scriptable object are data containers that you can use to save large amounts of data, independent of class instances. Great for global variables.
/// </summary>

[CreateAssetMenu(fileName = "New IntValue", menuName = "Scriptables/IntValue")]
public class SO_IntValue : ScriptableObject
{
    public int Value;
    public event Action<int> OnValueChanged;

    public void Set(int newValue)
    {
        Debug.Log($"Setting Int Value from {Value} to {newValue}");
        if (Value != newValue)
        {
            Value = newValue;
            OnValueChanged?.Invoke(newValue);
        }
    }


    public void Subtract()
    {
        Set(Value - 1);
    }

    public void Add()
    {
        Set(Value + 1);
    }
}
