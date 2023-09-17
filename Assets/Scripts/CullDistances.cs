using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CullDistances : MonoBehaviour
{
    void Awake()
    {
        Camera camera = GetComponent<Camera>();
        float[] distances = new float[32];
        distances[10] = 5;
        camera.layerCullDistances = distances;
    }

}
