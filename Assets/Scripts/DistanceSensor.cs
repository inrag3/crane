using System;
using UnityEngine;

public class DistanceSensor : Sensor, IInitializable<Container>
{
    [SerializeField] private LayerMask _obstacle;
    private Container _container;
    private Vector3 _size;

    public void Initialize(Container container)
    {
        _container = container;
    }
    
    protected override void Update()
    {
        base.Update();
        if (!_container)
        {
            transform.position = Vector3.zero;
            return;
        }
        transform.position = new Vector3(0, _container.transform.position.y, 0f);
    }
    
    protected override float GetValue()
    {
        var ray = new Ray(transform.position, -transform.up);
        if (Physics.Raycast(ray, out var hit, Mathf.Infinity, _obstacle))
        {
            print($"Столкновение с объектом: {hit.collider.gameObject.name} " + hit.distance);
        }
        return hit.distance;
    }
}

public interface IInitializable<in T>
{
    public void Initialize(T value);
}