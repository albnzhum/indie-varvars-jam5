using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject[] trackPrefabs;
    public Transform train; 
    public float spawnDistance = 10f; 
    public int maxSegments = 10; 

    private Vector3 spawnPosition;
    private int segmentsSpawned = 0;

    private void Start()
    {
        spawnPosition = train.position;
        SpawnInitialSegments();
        if (Waypoints.waypoints == null)
        {
            Waypoints.waypoints = new List<Transform>();
        }
    }

    private void Update()
    {
        if (Vector3.Distance(train.position, spawnPosition) > spawnDistance)  
        {
            SpawnInitialSegments();
            DestroyOldestSegment();
        }
    }

    private void SpawnInitialSegments()
    {
        while (segmentsSpawned < maxSegments)
        {
            SpawnSegment();
            segmentsSpawned++;
        }
    }
    
    private void SpawnSegment()
    {
        GameObject newTrack = Instantiate(trackPrefabs[0], spawnPosition, Quaternion.identity);
        spawnPosition.x += newTrack.GetComponentInChildren<Renderer>().bounds.size.x;
        //Waypoints.waypoints.Add(newTrack.transform);
    }

    private void DestroyOldestSegment()
    {
        GameObject[] segments = GameObject.FindGameObjectsWithTag("TrackSegment");
        foreach (GameObject segment in segments)
        {
            RailSegment railSegment = segment.GetComponent<RailSegment>();
            if (railSegment != null && railSegment.IsPassed(train.position))
            {
                Destroy(segment);
                segmentsSpawned--;
            }
        }
    }
}
