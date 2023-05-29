using System;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    [SerializeField] private float _value;
    [SerializeField] private Vector3 _direction;

    public float Value
    {
        get => _value;
        set => _value = value;
    }
    private void OnTriggerStay(Collider other)
    {
        if (!other.TryGetComponent(out Rigidbody rigidBody))
            return;
        var x = 0f;
        var z = 0f;
        if (_direction.x == 0)
            z = rigidBody.transform.position.z;
        if (_direction.z == 0) 
            x = rigidBody.transform.position.x;
        var targetPosition = new Vector3(x, rigidBody.transform.position.y, z);
        var force = targetPosition - rigidBody.position;
        rigidBody.AddForce(force, ForceMode.VelocityChange);
        rigidBody.AddForce(_direction * Value * (_direction.z == 0 ? 2.5f : 1f), ForceMode.VelocityChange);
    }
}