using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Container : MonoBehaviour
{
    private Rigidbody _rigidbody;

    public Rigidbody Rigidbody => _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public Vector3 TopCenter()
    {
        var halfHeight = transform.localScale.y / 2f;
        var centerPosition = transform.position;
        return new Vector3(centerPosition.x, centerPosition.y + halfHeight, centerPosition.z);
    }
}
