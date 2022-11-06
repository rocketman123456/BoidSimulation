using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BoidSettings
{
    // These fields allow you to adjust the flocking behavior of the Boids
    public int velocity = 32;
    public int neighborDist = 10;
    public int nearDist = 4;
    public int attractPushDist = 5;
    [Header("These \"influences\" are floats, usually from [0…4]")]           // b
    public float velMatching = 1.5f;
    public float flockCentering = 1f;
    public float nearAvoid = 2f;
    public float attractPull = 1f;
    public float attractPush = 20f; // Very strong to spread out the Boids

    [Header("This determines how quickly Boids can turn and is [0…1]")]
    public float velocityEasing = 0.03f;
}

public class Spawner : MonoBehaviour
{
    static public BoidSettings SETTINGS;
    static public List<Boid> BOIDS;


    [Header("Inscribed: Settings for Spawning Boids")]
    public GameObject boidPrefab;                                   // e
    public Transform boidAnchor;                                   // e
    public int numBoids = 100;
    public float spawnRadius = 100f;
    public float spawnDelay = 0.1f;

    [Header("Inscribed: Settings for Spawning Boids")]
    public BoidSettings boidSettings;

    void Awake()
    {
        Spawner.SETTINGS = boidSettings;

        BOIDS = new List<Boid>();
        InstantiateBoid();
    }

    public void InstantiateBoid()
    {
        GameObject go = Instantiate<GameObject>(boidPrefab);
        go.transform.position = Random.insideUnitSphere * spawnRadius;
        Boid b = go.GetComponent<Boid>();
        b.transform.SetParent(boidAnchor);
        BOIDS.Add(b);
        if (BOIDS.Count < numBoids)
        {
            Invoke("InstantiateBoid", spawnDelay);
        }
    }
}
