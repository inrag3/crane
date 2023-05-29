using UnityEngine;

public class AngleSensor : Sensor
{
    [SerializeField] private Wind _wind;
    protected override float GetValue() => _wind.Value;
    
}