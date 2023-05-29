using System;
using UnityEngine;

public abstract class Sensor : MonoBehaviour
{
    public float Value { get; private set; }

    protected abstract float GetValue();
    
    protected virtual void Update()
    {
        Value = GetValue();
    }
}