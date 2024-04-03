using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoidController : MonoBehaviour
{
    
    public float minSpeed;
    public float maxSpeed;
    [Space(10)]
    public float spawnRadius;
    public float spawnCount;
    [Space(10)]
    public GameObject boidPrefab;
    
    private void Start()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            //StartCoroutine(startSpawn());
            Spawn();
        }
    }

    IEnumerator startSpawn()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Spawn();
            yield return new WaitForSeconds(0.01f);
        }
    }
    
    private GameObject Spawn()
    {
        return Spawn(transform.position + Random.insideUnitSphere * spawnRadius);
    }

    private GameObject Spawn(Vector3 position)
    {
        var rotation = Quaternion.Slerp(transform.rotation, Random.rotation, 0.3f);
        var boid = Instantiate(boidPrefab, position, rotation) as GameObject;
        boid.GetComponent<BoidBehaviour>().controller = this;

        return boid;
    }

    public float getSpeed()
    {
        return Random.Range(minSpeed, maxSpeed);
    }
}
