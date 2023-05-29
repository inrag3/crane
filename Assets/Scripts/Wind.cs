using System;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    [SerializeField] private float _value;
    [SerializeField] private Vector3 _direction;
    private float _previousValue;

    public float Value
    {
        get => _value;
        set => _value = value - 0.5f;
    }
    private void OnTriggerStay(Collider other)
    {
        
        if (!other.TryGetComponent(out Rigidbody rigidBody))
            return;
        _previousValue = Value;
        var x = 0f;
        var z = 0f;
        if (_direction.x == 0)
            z = rigidBody.transform.position.z;
        if (_direction.z == 0) 
            x = rigidBody.transform.position.x;
        var targetPosition = new Vector3(x, rigidBody.transform.position.y, z);
        var force = targetPosition - rigidBody.position;
        rigidBody.AddForce(force, ForceMode.VelocityChange);
        rigidBody.AddForce(_direction * Value * (_direction.z == 0 ? 5f : 2f), ForceMode.VelocityChange);
    }
}