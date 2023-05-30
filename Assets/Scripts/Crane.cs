using System;
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
    [SerializeField] private float _horizontalMultipliyer = 2f;
    [SerializeField] private float _verticalMultipliyer = 2f;
    
    
    public bool IsFight { get; set; }
    public Container Container => _currentContainer;

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
    
    private void FixedUpdate()
    {
        var position = new Vector3(_hook.position.x, transform.position.y, _hook.transform.position.z);
        _lineRenderer.SetPosition(0, position);
        _lineRenderer.SetPosition(1, _currentContainer ? _currentContainer.TopCenter() : position);
        if (!_currentContainer) 
            return;
        var output = _rules.GetOutput(_distanceSensor, _horizontalSensor, _verticalSensor);
        var speed = output.Output switch
        {
            Output.Slow => 0.05f,
            Output.Moderate => 0.1f,
            Output.Fast => 0.3f,
            _ => throw new ArgumentOutOfRangeException()
        };

      
        
        if (_distanceSensor.Value < 0.05f)
        {
            _ship.AddContainer(_currentContainer);
            var pos = _distanceSensor.transform.position;
            _distanceSensor.Initialize(null);
            _currentContainer = null;
            return;
        }
        
        _currentContainer.Rigidbody.AddForce(
            0, 
            -speed, 
            0, 
            ForceMode.VelocityChange);


        var horizontal = output.Horizontal switch
        {
            Direction.None => 0.01f,
            Direction.Weak => 0.3f,
            Direction.Strong => 0.5f,
            _ => throw new ArgumentOutOfRangeException()
        };
        
        var vertical = output.Vertical switch
        {
            Direction.None => 0.01f,
            Direction.Weak => 0.3f,
            Direction.Strong => 0.5f,
            _ => throw new ArgumentOutOfRangeException()
        };
        _hook.transform.position = new Vector3(-_horizontalSensor.Value*horizontal*_horizontalMultipliyer, _hook.transform.position.y, -_verticalSensor.Value*vertical*_verticalMultipliyer);
        print(-Mathf.Sign(_horizontalSensor.Value)*horizontal);
        
        _currentContainer.Rigidbody.AddForce(
            -_horizontalSensor.Value*horizontal*_horizontalMultipliyer, 
            0, 
            -_verticalSensor.Value*vertical*_verticalMultipliyer, 
            ForceMode.VelocityChange);
    }
}