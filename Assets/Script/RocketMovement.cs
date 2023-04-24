using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    // The speed of the character 
    public float speed;

    // The rotation speed of the character
    public float rotationSpeed;

    // The boost strength of the character
    public float boostStrength;

    // The flag to determine if the character is flipping
    private bool isFlipping = false;

    // The Rigidbody2D component of the character
    private Rigidbody2D rb;

    // The time threshold for detecting double tap
    public float doubleTapTimeThreshold = 0.2f;

    // The time of the last space bar press
    private float lastSpaceBarPressTime;

    void Start()
    {
        // Get the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame 
    void Update()
    {
        // Rotate the character left 
        if (!isFlipping && Input.GetKey(KeyCode.LeftArrow))
        {
            rb.angularVelocity = rotationSpeed; // Set angular velocity to achieve left rotation
        }
        // Rotate the character right
        else if (!isFlipping && Input.GetKey(KeyCode.RightArrow))
        {
            rb.angularVelocity = -rotationSpeed; // Set angular velocity to achieve right rotation
        }
        // Slowly stop rotating the character when no arrow keys are pressed
        else
        {
            rb.angularVelocity *= 0.0015f; // Gradually reduce angular velocity to slow down rotation
        }

        // Boost the character with spacebar
        if (!isFlipping && Input.GetKey(KeyCode.Space))
        {
            // Increase boost strength over time
            float boost = boostStrength * Time.deltaTime;
            rb.AddForce(transform.up * boost, ForceMode2D.Force);
        }

        // Flip the character with double spacebar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Check if space bar was double tapped
            if (!isFlipping && (Time.time - lastSpaceBarPressTime) <= doubleTapTimeThreshold)
            {
                isFlipping = true;
                StartCoroutine(FlipCharacter());
            }

            // Update the last space bar press time
            lastSpaceBarPressTime = Time.time;
        }
    }

    // Co-routine to flip the character
    IEnumerator FlipCharacter()
    {
        // Flip character instantly
        transform.Rotate(Vector3.forward, 180f);

        // Wait for a short duration to prevent double input
        yield return new WaitForSeconds(0.5f);

        // Reset flip flag
        isFlipping = false;
    }
}
