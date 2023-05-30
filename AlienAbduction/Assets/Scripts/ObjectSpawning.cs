using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectSpawning : MonoBehaviour
{
    #region Variables: Spawning

    [SerializeField] private GameObject spawningObject;
    [SerializeField] private Transform startPoint, endPoint;


    private Vector3 spawnPoint;

    [SerializeField] private float spawnTime = 0f;
    [SerializeField] private float spawnDelay;
    [SerializeField] private int spawnCount;
    [SerializeField] private int maxCount = 9;

    private float percent;
    private int index = 0;

    private bool spawning = true;
    
   

    #endregion

    // Start is called before the first frame update

    void Start()
    {
        spawnCount = 0; // initial amount of spawns 
        percent = 1f / 10f;
    }

    // Update is called once per frame
    
    void Update()
    {
        if (spawning)
        {
            spawnTime += Time.deltaTime;

            if (spawnTime >= spawnDelay && spawnCount <= maxCount)
            {
                spawnObject();
                spawnTime = 0f;
                index ++;
            }
        }
    }

    public void spawnObject()
    {

        spawnPoint = Vector3.Lerp(startPoint.position, endPoint.position, percent * index);
        GameObject spawnInstance = Instantiate(spawningObject);
        spawnInstance.transform.position = spawnPoint;
        
       spawnCount++;
        
    }
}
