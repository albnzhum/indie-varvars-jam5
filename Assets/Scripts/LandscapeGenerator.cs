using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class LandscapeGenerator : MonoBehaviour
{
    public Camera mainCamera;
    public Transform startPoint;
    public LandscapeSegment prefab;
    public float movingSpeed = 12;
    public int tilesToPreSpawn = 15;

    private List<LandscapeSegment> spawnedTiles = new List<LandscapeSegment>();
    private int nextTileToActivate = -1;
    [HideInInspector] 
    public bool gameOver = false;

    private static bool gameStarted = false;
    private float score = 0;

    public static LandscapeGenerator _instance;
    
    private void Awake()
    {
        _instance = this;
        Vector3 spawnPosition = startPoint.position;
        for (int i = 0; i < tilesToPreSpawn; i++)
        {
            // Only modify the Z component of spawnPosition
            spawnPosition.z -= prefab.startPoint.localPosition.z;

            // Use the modified spawnPosition to instantiate the tile
            LandscapeSegment spawnedTile = Instantiate(prefab, spawnPosition, transform.rotation) as LandscapeSegment;
        
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
            LandscapeSegment railTmp = spawnedTiles[0];
            spawnedTiles.RemoveAt(0);
            Vector3 temp = spawnedTiles[spawnedTiles.Count - 1].endPoint.position -
                                         railTmp.startPoint.localPosition;
            railTmp.transform.position = new Vector3(startPoint.position.x, startPoint.position.y, temp.z+30f);
            railTmp.ActivateObstacle();
            spawnedTiles.Add(railTmp);
        }
    }
}
