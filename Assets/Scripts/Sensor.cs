using System;
using UnityEngine;

public abstract class Sensor : MonoBehaviour
{
    public float Value { get; private set; }

    protected abstract float GetValue();
    
    private void Update()
    {
        Value = GetValue();
    }
}