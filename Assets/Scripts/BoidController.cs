using UnityEngine;
using System.Collections;
public class BoidController : MonoBehaviour
{
    public float speed;
    public float spawnRadius;
    public float spawnCount;
    public GameObject boidPrefab;

    private void Start()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Spawn();
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
}
