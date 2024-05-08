using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    private bool isPaused = false;
    private Rigidbody2D[] rigidbodies;
    private Vector2[] orignalVelocities;
    private Vector2[] originalPositions;
    private float[] originalGravityScale;
    private PlayerController playerController;

    void Start()
    {
        rigidbodies = FindObjectsOfType<Rigidbody2D>();
        orignalVelocities = new Vector2[rigidbodies.Length];
        originalPositions = new Vector2[rigidbodies.Length];
        originalGravityScale = new float[rigidbodies.Length];

        for(int i = 0;i < rigidbodies.Length; i++)
        {
            orignalVelocities[i] = rigidbodies[i].velocity;
            originalPositions[i] = rigidbodies[i].position;
            originalGravityScale[i] = rigidbodies[i].gravityScale;
        }
        playerController = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0;
            foreach(Rigidbody2D rb in rigidbodies)
            {
                rb.velocity = Vector2.zero;
                rb.gravityScale = -9;
                rb.bodyType = RigidbodyType2D.Kinematic;
            }
            playerController.enabled = false;   
        }
        else
        {
            Time.timeScale = 1;
            for(int i = 0;i < rigidbodies.Length;i++)
            {
                
                rigidbodies[i].velocity = orignalVelocities[i];
                rigidbodies[i].position = originalPositions[i];
                rigidbodies[i].gravityScale = originalGravityScale[i];
                rigidbodies[i].bodyType = RigidbodyType2D.Dynamic;
            }
            playerController.enabled = true;
        }

       

    }
}
