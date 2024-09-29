using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Two_Obstacle : MonoBehaviour
{
    private float targetY = 5f; // Maximum position on the y-axis
    private float speed = 1f; // Speed of movement
    private float startY = 0.5f; // Minimum position on the y-axis

    // Update is called once per frame
    void Update()
    {
        // Calculate new Y position using sine wave for oscillation
        float newY = Mathf.Lerp(startY, targetY, (Mathf.Sin(Time.time * speed) + 1) / 2);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
