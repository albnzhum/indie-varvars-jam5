using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailSegment : MonoBehaviour
{
    private bool isPassed = false;

    // Метод для проверки, прошел ли поезд через этот сегмент
    public bool IsPassed(Vector3 trainPosition)
    {
        if (!isPassed && trainPosition.x > transform.position.x)
        {
            isPassed = true;
            return true;
        }
        return false;
    }
}
