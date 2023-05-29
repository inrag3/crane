using System;
using System.Collections.Generic;
using UnityEngine;

public class Rules : MonoBehaviour
{
    [SerializeField] private List<Rule> _rules;
    private Membership _veryCloseDistance;
    private Membership _closeDistance;
    private Membership _mediumDistance;
    private Membership _farDistance;
    private Membership _weakWindSpeed;
    private Membership _moderateWindSpeed;
    private Membership _strongWindSpeed;


    private void Awake()
    {
        _closeDistance = new Membership(new[] { 0f, 0.5f, 1.5f, 3f });
        _mediumDistance = new Membership(new[] { 1.5f, 3f, 20f, 30f });
        _farDistance = new Membership(new[] { 25f, 35f, 40f, 40f });
        
        _weakWindSpeed = new Membership(new[] { 0f, 0f, 5f, 10f });
        _moderateWindSpeed = new Membership(new[] { 5f, 10f, 15f, 20f });
        _strongWindSpeed = new Membership(new[] { 15f, 20f, 25f, 25f });
    }


    private DistanceInput DistanceInput(DistanceSensor sensor)
    {
        
        
        
        
        return global::DistanceInput.Far;
    }


    private WindInput DirectionInput(AngleSensor sensor)
    {
        var weak = _weakWindSpeed.Get(sensor.Value);
        var moderate = _moderateWindSpeed.Get(sensor.Value);
        var strong = _strongWindSpeed.Get(sensor.Value);
        
        
        return WindInput.Fast;
    }


    public Output GetOutput(DistanceSensor sensor, AngleSensor horizontalSensor, AngleSensor verticalSensor)
    {
        var distanceInput = DistanceInput(sensor);
        var horizontalInput = DirectionInput(horizontalSensor);
        var verticalInput = DirectionInput(verticalSensor);
        return _rules.Find(x => x.distance == distanceInput && 
                                x.horizontal == horizontalInput &&
                                x.vertical == verticalInput).speed;
    }
}