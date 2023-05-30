using UnityEngine;
using UnityEngine.UI;

public class CraneView : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Crane _crane;


    private void OnEnable()
    {
        _button.onClick.AddListener(ContainerInstantiate);
    }
    
    private void OnDisable()
    {
        _button.onClick.RemoveListener(ContainerInstantiate);
    }

    private void ContainerInstantiate()
    {
        if (!_crane.Container)
            _crane.ContainerInstantiate();
    }
}