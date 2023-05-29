﻿using System;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Crane : MonoBehaviour
{
    [SerializeField] private Ship _ship;
    [SerializeField] private Container _container;
    [SerializeField] private Transform _place;
    [SerializeField] private Transform _hook;
    [SerializeField] private AngleSensor _horizontalSensor;
    [SerializeField] private AngleSensor _verticalSensor;
    [SerializeField] private DistanceSensor _distanceSensor;
    [SerializeField] private Rules _rules;

    private LineRenderer _lineRenderer;

    private Container _currentContainer;

    public void ContainerInstantiate() 
    {
        _currentContainer = Instantiate(_container, _place.transform.position, _container.transform.rotation, transform);
        _distanceSensor.Initialize(_currentContainer);
    }
    
    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.positionCount = 2;
    }
    
    private void Update()
    {
        var position = new Vector3(_hook.position.x, transform.position.y, 0);
        _lineRenderer.SetPosition(0, position);
        _lineRenderer.SetPosition(1, _currentContainer ? _currentContainer.TopCenter() : position);
        if (!_currentContainer) 
            return;
        var output = _rules.GetOutput(_distanceSensor, _horizontalSensor, _verticalSensor);
        print(output.Output);
        var speed = output.Output switch
        {
            Output.Slow => 0.03f,
            Output.Moderate => 0.1f,
            Output.Fast => 0.3f,
            _ => throw new ArgumentOutOfRangeException()
        };
        if (_distanceSensor.Value < 0.05f)
        {
            _ship.AddContainer(_currentContainer);
            _currentContainer = null;
            return;
        }
        _currentContainer.Rigidbody.AddForce(0, -speed, 0, ForceMode.VelocityChange);
    }
}