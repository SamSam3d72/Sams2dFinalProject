using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBehavior : MonoBehaviour
{
    // Reference to the player object
    private Transform Rocket;

    // The force applied to the Eyes to move towards the player
    public float attractionForce = 10f;

    // The range at which the Eyes are attracted to the player
    public float attractionRange = 10f;

    // The maximum number of Eyes that can be attracted to the player at once
    public int maxAttractionCount = 5;

    // The radius of the circle within which the Eyes are spawned around the Mouth
    public float spawnRadius = 1f;

    // The number of Eyes to spawn
    public int spawnCount = 10;

    // Reference to the Eye prefab
    public GameObject eyePrefab;

    // List to store the references to the spawned Eyes
    private List<GameObject> spawnedEyes = new List<GameObject>();

    void Start()
    {
        // Spawn Eyes around the Mouth
        for (int i = 0; i < spawnCount; i++)
        {
            Vector2 spawnPosition = (Vector2)transform.position + Random.insideUnitCircle * spawnRadius;
            GameObject eye = Instantiate(eyePrefab, spawnPosition, Quaternion.identity);
            spawnedEyes.Add(eye);
        }
    }

    void Update()
    {
        // Attract Eyes towards the player
        int attractedCount = 0;
        foreach (GameObject eye in spawnedEyes)
        {
            if (attractedCount >= maxAttractionCount) break;

            Vector2 attractionDirection = Rocket.position - eye.transform.position;
            float distance = attractionDirection.magnitude;
            if (distance <= attractionRange)
            {
                eye.GetComponent<Rigidbody2D>().AddForce(attractionDirection.normalized * attractionForce);
                attractedCount++;
            }
        }
    }
}
