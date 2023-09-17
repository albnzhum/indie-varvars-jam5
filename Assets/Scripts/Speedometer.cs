using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speedometer : MonoBehaviour
{
    public TrainMovement train;
    public RectTransform pointer;
    public Text speed;
    public float minSpeed;
    public float maxSpeed;
    public GameObject warning;
    
    private void Update()
    {
        speed.text = (int)train.speed + "";
        pointer.localEulerAngles = new Vector3(0, 0, Mathf.Lerp(minSpeed, maxSpeed, train.speed / train.maxSpeed));
    }

    public void IncreaseSpeed()
    {
        
        if (train.maxSpeed != 30)
        {train.maxSpeed++;
            
        }
        else
        {
            StartCoroutine(ActiveWarning(4));
        }
    }

    IEnumerator ActiveWarning(float delay)
    {
        warning.SetActive(true);
        yield return new WaitForSeconds(delay);
        warning.SetActive(false);
    }
    
    public void PauseGame ()
    {
        Time.timeScale = 0;
    }
    public void ResumeGame ()
    {
        Time.timeScale = 1;
    }
}
