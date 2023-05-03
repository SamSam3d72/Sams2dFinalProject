using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouthBehavior : MonoBehaviour
{
    // The eye prefab to spawn
    public GameObject eyePrefab;

    // The time interval between eye spawns
    public float spawnInterval = 2f;

    // The number of eyes to spawn each time the mouth opens
    public int numEyesToSpawn = 3;

    // The flag to determine if the mouth is open
    private bool isOpen = false;

    // The time of the last eye spawn
    private float lastSpawnTime = 0f;

    void Start()
    {
        // Set the last spawn time to the current time
        lastSpawnTime = Time.time;
    }

    void Update()
    {
        // Check if it's time to spawn new eyes
        if (isOpen && Time.time - lastSpawnTime >= spawnInterval)
        {
            // Spawn the specified number of eyes
            for (int i = 0; i < numEyesToSpawn; i++)
            {
                // Instantiate a new eye object at the Mouth's position
                GameObject newEye = Instantiate(eyePrefab, transform.position, Quaternion.identity);

                // Set the new eye object's parent to the Mouth object
                newEye.transform.parent = transform;
            }

            // Update the last spawn time
            lastSpawnTime = Time.time;
        }
    }

    // Method to open the mouth
    public void OpenMouth()
    {
        isOpen = true;
    }

    // Method to close the mouth
    public void CloseMouth()
    {
        isOpen = false;
    }
}
