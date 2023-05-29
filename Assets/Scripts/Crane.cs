using System;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Crane : MonoBehaviour
{
    [SerializeField] private Ship _ship;
    [SerializeField] private Container _container;
    [SerializeField] private Transform _place;
    [SerializeField] private Transform _hook;
    private LineRenderer _lineRenderer;
    private Rules _rules;
    
    private Container _currentContainer;
    public Container Container => _currentContainer;

    private void ContainerInstantiate() => 
        _currentContainer = Instantiate(_container, _place.transform.position, _container.transform.rotation, transform);

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.positionCount = 2;
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
        var position = new Vector3(_hook.position.x, transform.position.y, 0);
        _lineRenderer.SetPosition(0, position);
        _lineRenderer.SetPosition(1, _currentContainer.TopCenter());
    }
    
    //TODO Написать функцию которая генерирует экспертная функция.
}