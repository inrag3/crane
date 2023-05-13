using System;
using UnityEngine;

public class CameraSetup : MonoBehaviour
{
    [SerializeField] private Camera _topCamera;

    private void Awake()
    {
        _topCamera.enabled = true;
    }

    private void Start()
    {
        // Установка позиции и размеров камеры сверху
        _topCamera.rect = new Rect(0.7f, 0.7f, 0.3f, 0.3f);
    }
}