using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class PalyerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public Button restartButton; // Add this line

    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;

    // New method to restart the game
    public void RestartGame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;

        setCountText();

        winTextObject.SetActive(false);
    }

    void OnMove(InputValue movementValue) //vector2 type (x,y)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;

    }

    void setCountText()
    {
        countText.text = "count: " + count.ToString();
        if(count >= 12)
        {
            winTextObject.SetActive(true);
            restartButton.gameObject.SetActive(true); // Show the restart button
        }
        else
        {
            restartButton.gameObject.SetActive(false); // Hide the restart button if not all coins are collected
        }
    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX,0.0f,movementY);
        rb.AddForce(movement * speed);     // add force is of type vector3 (x,y,z)
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count +1;

            setCountText();
        }
        
    }
}
