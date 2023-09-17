using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailSegment : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public GameObject obstacle;

    public void ActivateObstacle()
    {
        DeactiveObstacle();
        obstacle.SetActive(true);
    }

    public void DeactiveObstacle()
    {
        obstacle.SetActive(false);
    }

}
