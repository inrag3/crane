using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Crane : MonoBehaviour
{
    [SerializeField] private Ship _ship;
    [SerializeField] private Container _container;
    [SerializeField] private Transform _hook;
    private LineRenderer _lineRenderer;
    private IEnumerable<Sensor> _sensors;

    private Container _currentContainer;

    private void ContainerInstantiate() => 
        _currentContainer = Instantiate(_container, _hook.transform.position, Quaternion.identity, transform);

    private void Awake()
    {
        _sensors = GetComponentsInChildren<Sensor>();
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.positionCount = 2;
        _lineRenderer.SetPosition(0, transform.position);
        ContainerInstantiate();
    }

    private void OnEnable()
    {
        _ship.ContainerDipped += ContainerInstantiate;
    }

    private void OnDisable()
    {
        _ship.ContainerDipped -= ContainerInstantiate;
    }
    
    private void Update()
    {
        _lineRenderer.SetPosition(1, _currentContainer.TopCenter());
        if (Input.GetKeyDown(KeyCode.A))
        {
            _ship.AddContainer(_currentContainer);
        }
    }
    
    //TODO Написать функцию которая генерирует экспертная функция.
}

