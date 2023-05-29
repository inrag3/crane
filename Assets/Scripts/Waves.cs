using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour
{
    [SerializeField] int _maxHeight = 0;
    [SerializeField] int _minHeight = -5;
    [SerializeField] private float _lerpValue = 2f;
    [SerializeField] private Vector3 _offset;
    
    
    public float Lerp
    {
        get => _lerpValue;
        set => _lerpValue = value;
    }
    
    private Transform _ship;
    private bool _goingUp = false;
    private Vector3 _velocity;

    private void Awake()
    {
        _ship = GameObject.Find("Ship").transform;
        transform.position = _ship.position - _offset;
    }

    private void FixedUpdate()
    {
        if (_goingUp)
        {
            GoUp(new Vector3(-0.7f, Random.Range(_minHeight, _maxHeight), 0));
        }
        else
        {
            GoDown(new Vector3(-0.7f, _minHeight, 0));
        }
    }


    //Двигаемся к рандомной высоте
    private void GoUp(Vector3 target)
    {
        if (Vector3.Distance(transform.position, target) > 0.05f) 
        {
            transform.position = Vector3.SmoothDamp(transform.position, target, ref _velocity, _lerpValue);
            _ship.position = Vector3.SmoothDamp(_ship.position, target + _offset, ref _velocity, _lerpValue);
        }
        else
        {
            _goingUp = false;
        }
    }

    //Двигаемся к MinHeight
    private void GoDown(Vector3 target)
    {
        if (Vector3.Distance(transform.position, target) > 0.05f) 
        {
            transform.position = Vector3.SmoothDamp(transform.position, target, ref _velocity, _lerpValue);
            _ship.position = Vector3.SmoothDamp(_ship.position, target + _offset, ref _velocity, _lerpValue);
        }
        else
        {
            _goingUp = true;
        }
    }
}
