using System;
using UnityEngine;

public class WindView : View
{
    [SerializeField] private Wind _wind;

    protected override void OnValueChanged(float value)
    {
        _wind.Value = value;
    }
}