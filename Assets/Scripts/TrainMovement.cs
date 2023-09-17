using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrainMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public float acceleration = 2.0f;
    public float maxSpeed = 10.0f;
    public float rotationSpeed = 5.0f;

    public Transform railContainer;
    private List<Transform> waypoints; // Узлы системы путей (места, куда должен двигаться поезд)
    private int currentWaypointIndex = 0;
    private Vector3 spawnPosition;
    private Vector3 moveDirection;

    private void Awake()
    {
        this.enabled = false;
    }

    private void Start()
    {
        // Получите все рельсы (узлы) из контейнера RailContainer
        waypoints = new List<Transform>();
        foreach (Transform child in railContainer)
        {
            waypoints.Add(child);
        }

       // spawnPosition = transform.position;
    }

    private void Update()
    {
        if (waypoints.Count == 0)
        {
            Debug.LogError("Waypoints are missing.");
            return;
        }

        //Vector3 targetPosition = waypoints[currentWaypointIndex].position;
        Vector3 targetPosition = new Vector3(0.46f, 1.3f, waypoints[currentWaypointIndex].position.z);

        moveDirection = (targetPosition - transform.position).normalized;

        speed += acceleration * Time.deltaTime;
        speed = Mathf.Clamp(speed, 0, maxSpeed);

        transform.position += moveDirection * speed * Time.deltaTime;

        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            Debug.Log(currentWaypointIndex);
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Count)
            {
                currentWaypointIndex = 0;
            }
        }
    }
    
}
