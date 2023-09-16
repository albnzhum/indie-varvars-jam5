using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public float acceleration = 2.0f;
    public float maxSpeed = 10.0f;
    public float rotationSpeed = 5.0f;

    public List<Transform> waypoints; // Узлы системы путей (места, куда должен двигаться поезд)
    private int currentWaypointIndex = 0;

    private void Update()
    {
        if (waypoints.Count == 0)
        {
            Debug.LogError("Waypoints are missing.");
            return;
        }

        // Перемещение к текущему узлу
        Vector3 targetPosition = waypoints[currentWaypointIndex].position;
        Vector3 moveDirection = (targetPosition - transform.position).normalized;
        
        // Ускоряем поезд
        speed += acceleration * Time.deltaTime;
        speed = Mathf.Clamp(speed, 0, maxSpeed);

        // Перемещаем поезд
        transform.position += moveDirection * speed * Time.deltaTime;

        // Если поезд достиг текущего узла, переходим к следующему
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            currentWaypointIndex++;

            // Проверка, достиг ли поезд последнего узла, и перезапуск маршрута
            if (currentWaypointIndex >= waypoints.Count)
            {
                currentWaypointIndex = 0;
            }
        }
    }

    // Метод для установки узлов системы путей
    public void SetWaypoints(List<Transform> newWaypoints)
    {
        waypoints = newWaypoints;
        currentWaypointIndex = 0;
    }
}
