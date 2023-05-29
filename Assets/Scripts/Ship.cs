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
            Invoke(nameof(Restart), 1f);
        }
        container.gameObject.layer = 3;
        ContainerDipped?.Invoke();
    }
    
    private void Restart() => SceneManager.LoadScene(0);
    
}