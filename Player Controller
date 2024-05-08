using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 3.0f;
    private TimerManager timerManager;
   
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        timerManager = TimerManager.instance;
        timerManager.StartTimer();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPosition = transform.position;

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                currentPosition.x -= movementSpeed;
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
            currentPosition.x += movementSpeed;
            }
        Camera mainCamera = Camera.main;

        float halfPlayerWidth = GetComponent<SpriteRenderer>().bounds.extents.x;
        float clampedX = Mathf.Clamp(currentPosition.x, mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + halfPlayerWidth, mainCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - halfPlayerWidth);

        transform.position = new Vector3(clampedX, currentPosition.y, currentPosition.z);
    }
    
   
}
