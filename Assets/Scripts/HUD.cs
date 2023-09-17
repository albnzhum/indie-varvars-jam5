using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] private Slider speedometer;
    public TrainMovement train;

    private void Start()
    {
        speedometer.minValue = train.speed;
        speedometer.maxValue = train.maxSpeed;
    }

    private void Update()
    {
        speedometer.value = train.speed;
    }
}
