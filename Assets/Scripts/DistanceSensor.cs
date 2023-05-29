using UnityEngine;

public class DistanceSensor : Sensor
{
    [SerializeField] private float _maxDistance;

    protected override float GetValue()
    {
        var hit = Physics2D.Raycast(transform.position, -transform.up, _maxDistance);
        return hit.distance;
    }
}