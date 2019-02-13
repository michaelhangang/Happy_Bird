﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class columnpool : MonoBehaviour {
    public int columnPoolSize = 5;
    private GameObject[] columns;
    public GameObject columnPrefab;
    public float spawnRate = 4f;
    private Vector2 objectPoolPostion = new Vector2(-15f,-25f);
    private float timeSinceLastSpawned;
    public float columnMin = -1f;
    public float columnMax = 3.5f;
    private float spawnXPosition = 10f;
    private int currentColumn = 0;
	// Use this for initialization
	void Start () {
        columns = new GameObject[columnPoolSize];
        for (int i = 0; i < columnPoolSize; i++)
        {
            columns[i] = (GameObject)Instantiate(columnPrefab, objectPoolPostion, Quaternion.identity);

        }
	}
	
	// Update is called once per frame
	void Update () {
        timeSinceLastSpawned += Time.deltaTime;
        if (GameController.instance.gameover == false && timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0;
            float spawnYPosition = Random.Range(columnMin, columnMax);
    
            columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            currentColumn++;
            if (currentColumn >= columnPoolSize)
            {
                currentColumn = 0;
            }
        }
    }
}
