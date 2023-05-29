using System;
using System.Collections.Generic;
using UnityEngine;

public class Rules : MonoBehaviour
{
    [SerializeField] private List<DistanceRule> _rules;
    private Membership _veryCloseDistance;
    private Membership _closeDistance;
    private Membership _mediumDistance;
    private Membership _farDistance;
    private Membership _weakWindSpeed;
    private Membership _moderateWindSpeed;
    private Membership _strongWindSpeed;


    private void Awake()
    {
        _veryCloseDistance = new Membership(new[] { 0f, 1f });
        _closeDistance = new Membership(new[] { 0f, 1f, 1.5f, 2f });
        _mediumDistance = new Membership(new[] { 1.5f, 2f, 5.5f, 6f });
        _farDistance = new Membership(new[] { 5.5f, 6f, 15f, 15.5f });

        
        _weakWindSpeed = new Membership(new[] { 0f, 0.35f });
        _moderateWindSpeed = new Membership(new[] { 0f, 0.35f, 0.65f, 1f });
        _strongWindSpeed = new Membership(new[] { 0.65f, 1f});
    }


    private DistanceInput DistanceInput(DistanceSensor sensor)
    {
        var veryClose = _veryCloseDistance.Get2(sensor.Value);
        var close = _closeDistance.Get(sensor.Value);
        var medium = _mediumDistance.Get(sensor.Value);
        var far = _farDistance.Get(sensor.Value);

        var max = Mathf.Max(veryClose, close, medium, far);
        if (veryClose == max)
            return global::DistanceInput.Close;
        if (medium == max)
            return global::DistanceInput.Medium;
        return global::DistanceInput.Far;
        
    }

    private WindInput DirectionInput(AngleSensor sensor)
    {
        var value = Mathf.Abs(sensor.Value);
        var weak = _weakWindSpeed.Get2(value);
        var moderate = _moderateWindSpeed.Get(value);
        var strong = _strongWindSpeed.Get(value);
        
        var max = Mathf.Max(weak, moderate, strong);
        if (weak == max)
            return WindInput.Weak;
        if (moderate == max)
            return WindInput.Moderate;
        return WindInput.Strong;
    }


    public OutPut GetOutput(DistanceSensor sensor, AngleSensor horizontalSensor, AngleSensor verticalSensor)
    {
        var distanceInput = DistanceInput(sensor);
        var horizontalInput = DirectionInput(horizontalSensor);
        var verticalInput = DirectionInput(verticalSensor);
        print($"{distanceInput}, {horizontalInput}, {verticalInput}");
        var speed = _rules.Find(x => x.distance == distanceInput &&
                                     x.horizontal == horizontalInput &&
                                     x.vertical == verticalInput).OutPut;
        return speed;
    }
}
