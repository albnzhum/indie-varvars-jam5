using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class MapGenerator : MonoBehaviour
{
    public Camera mainCamera;
    public Transform startPoint;
    public RailSegment prefab;
    public float movingSpeed = 12;
    public int tilesToPreSpawn = 15;

    private List<RailSegment> spawnedTiles = new List<RailSegment>();
    private int nextTileToActivate = -1;
    [HideInInspector] 
    public bool gameOver = false;

    private static bool gameStarted = false;
    private float score = 0;

    public static MapGenerator _instance;

    private void Awake()
    {
        _instance = this;
        Vector3 spawnPosition = startPoint.position;
        for (int i = 0; i < tilesToPreSpawn; i++)
        {
            // Only modify the Z component of spawnPosition
            spawnPosition.z -= prefab.startPoint.localPosition.z;

            // Use the modified spawnPosition to instantiate the tile
            RailSegment spawnedTile = Instantiate(prefab, spawnPosition, transform.rotation) as RailSegment;
        
            // Update the spawnPosition for the next tile
            spawnPosition.z = spawnedTile.endPoint.position.z;
            spawnedTile.transform.SetParent(transform);
            spawnedTiles.Add(spawnedTile);
        }
    }

    private void Update()
    {
        if (!gameOver && gameStarted)
        {
            // Move only along the Z-axis, setting X and Y components to zero
            Vector3 moveDirection = -spawnedTiles[0].transform.forward;
            moveDirection.x = 0;
            moveDirection.y = 0;
        
            transform.Translate(moveDirection * (Time.deltaTime * (movingSpeed + (score/500))), Space.World);
            score += Time.deltaTime * movingSpeed;
        }

        if (mainCamera.WorldToViewportPoint(spawnedTiles[0].endPoint.position).z < 0)
        {
            RailSegment railTmp = spawnedTiles[0];
            spawnedTiles.RemoveAt(0);
            Vector3 temp = spawnedTiles[spawnedTiles.Count - 1].endPoint.position -
                                         railTmp.startPoint.localPosition;
            railTmp.transform.position = new Vector3(startPoint.position.x, startPoint.position.y, temp.z);
            railTmp.ActivateObstacle();
            spawnedTiles.Add(railTmp);
        }
    }
}
