using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint2 : MonoBehaviour
{
    Vector3[] pos;
    public GameObject[] obj;
    private float spawnTime;
    public float timeBetweenSpawn;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    

    void Start()
    {
       
     
    }

    void Update()
    {
        if (Time.time > spawnTime)
        {
            Spawn();
            spawnTime = Time.time + timeBetweenSpawn;
        }

        

    }

    void Spawn()
    {
        for (int i = 0; i < obj.Length; i++)
        {
            pos = new Vector3[obj.Length];
            pos[0] = new Vector3(transform.position.x, transform.position.y + i, transform.position.z);


            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);
             //Instantiate(obj[i], pos[0], transform.rotation);
           Instantiate(obj[i], pos[0] + new Vector3(randomX, randomY, 0), transform.rotation);
            
        }
    }
}
