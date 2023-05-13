using System;
using UnityEngine;

public class Wind : MonoBehaviour
{
    [SerializeField] private Vector3 _direction;

    [SerializeField] private Crane _crane;
    //TODO подумать над типами ветра.
    public float Value { get; set; }
    
    private void Update()
    {
        // var containerRigidbody = _crane.Container.Rigidbody;
        // containerRigidbody.AddForce(_direction * (Value), ForceMode.Acceleration);
    }
}
