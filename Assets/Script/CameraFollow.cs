using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target; // The target object (in this case, your player named "Rocket")
    public float smoothSpeed = 0.125f; // The smoothing speed of the camera movement
    public Vector3 offset; // The offset between the camera and the target

    void FixedUpdate()
    {
        if (target != null)
        {
            // Calculate the desired position of the camera based on the target position and offset
            Vector3 desiredPosition = new Vector3(target.transform.position.x + offset.x,
                                                  target.transform.position.y + offset.y,
                                                  transform.position.z); // Keep the Z-axis position unchanged

            // Smoothly move the camera towards the desired position using Lerp
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
