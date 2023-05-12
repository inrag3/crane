using System;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    private readonly List<Container> _containers = new List<Container>();
    public event Action ContainerDipped;
    
    public void AddContainer(Container container)
    {
        _containers.Add(container);
        container.transform.SetParent(transform);
        ContainerDipped?.Invoke();
    }
}