using UnityEngine;

public class WaveView : View
{
    [SerializeField] private Wave _wave;

    protected override void OnValueChanged(float value)
    {
        _wave.Value = value;
    }
}