using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBehavior : MonoBehaviour
{
    // The speed of the eye
    public float speed = 3f;

    // The Rocket object to follow
    private GameObject rocket;

    // The Rigidbody2D component of the eye
    private Rigidbody2D rb;

    void Start()
    {
        // Get a reference to the Rocket object
        rocket = GameObject.Find("Rocket");

        // Get the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (rocket != null)
        {
            // Calculate the direction to the Rocket
            Vector2 direction = rocket.transform.position - transform.position;

            // Normalize the direction vector
            direction.Normalize();

            // Move the eye in the direction of the Rocket
            rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            // Deal damage to the player
            other.gameObject.GetComponent<RocketHealth>().TakeDamage(10);

            // Destroy the eye
            Destroy(gameObject);
        }

        // Debug statement to check if method is being called
        Debug.Log("Trigger detected!");
    }
}
