using UnityEngine;

public class LerpView : View
{
    [SerializeField] private Waves _waves;

    protected override void OnValueChanged(float value)
    {
        _waves.Lerp = value;
    }
}