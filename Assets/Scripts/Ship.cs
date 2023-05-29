using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ship : MonoBehaviour
{
    private readonly List<Container> _containers = new List<Container>();
    
    public event Action ContainerDipped;
    
    public void AddContainer(Container container)
    {
        container.transform.SetParent(transform);
        _containers.Add(container);
        if (_containers.Count == 4)
        {
            SceneManager.LoadScene(0);
        }
        container.gameObject.layer = 3;
        ContainerDipped?.Invoke();
    }
    
    
}