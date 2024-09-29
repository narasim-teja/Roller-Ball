using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Three_Obstacle : MonoBehaviour
{
     private float targetX = 2.5f; // Maximum position on the x-axis
    private float speed = 1f; // Speed of movement
    private float startX = -2.5f; // Minimum position on the x-axis

    // Update is called once per frame
    void Update()
    {
        // Calculate new X position using sine wave for oscillation
        float newX = Mathf.Lerp(startX, targetX, (Mathf.Sin(Time.time * speed) + 1) / 2);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
}