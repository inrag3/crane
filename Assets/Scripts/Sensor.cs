using System;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    public float maxDistance = 10f; // Максимальная дальность луча

    private void Update()
    {
        var hit = Physics2D.Raycast(transform.position, -transform.up, maxDistance);
        if (hit.collider == null) 
            return;
        var distance = hit.distance;
        print(distance);
    }
}