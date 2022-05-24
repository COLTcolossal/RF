using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurseSpawn : MonoBehaviour
{
    public GameObject obstacle;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    private float timeBetweenSpawn = 4f;
    private float spawnTime;

    void Start()
    {
        StartCoroutine(GatlenCurse1());
        
        
    }

    // Update is called once per frame
    

    void Spawn()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        Instantiate(obstacle, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
    }

    private IEnumerator GatlenCurse1()
    {
        yield return new WaitForSeconds(10);
        StartCoroutine(GatlenCurse2());
        
       
        
        
    }

    private IEnumerator GatlenCurse2()
    {
        Debug.Log("one");
        yield return new WaitForSeconds(15);
        StartCoroutine(GatlenCurse3());
        
        
        
        
    }

    private IEnumerator GatlenCurse3()
    {
        Debug.Log("two");
        yield return new WaitForSeconds(20);
        
        
    }

    void Update()
    {
        
        if (Time.time > spawnTime)
        {
            Spawn();
            spawnTime = Time.time + timeBetweenSpawn;
        }


    }

}
