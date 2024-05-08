using UnityEngine;
using System.Collections;

public class PauseMenuExample : MonoBehaviour {

    private GameObject panel;

    private bool isPaused = false;

	void Awake () {
        // Get panel object
        panel = transform.Find("Panel").gameObject;
        if (panel == null) {
            Debug.LogError("Panel object not found.");
            return;
        }

        panel.SetActive(false); // Hide menu on start
	}
    
    // Call from inspector button
    public void ResumeGame () {
        isPaused = false;
        Time.timeScale = 1f;
        SumPause.Status = false; // Set pause status to false
        Debug.Log("button pressed");
        panel.SetActive(false);
    }


    // Add/Remove the event listeners
    void OnEnable() {
        SumPause.pauseEvent += OnPause;
    }

    void OnDisable() {
        SumPause.pauseEvent -= OnPause;
    }

    /// <summary>What to do when the pause button is pressed.</summary>
    /// <param name="paused">New pause state</param>
    void OnPause(bool paused) {
        if (paused) {
            isPaused = true;
            Time.timeScale = 0;
            // This is what we want do when the game is paused
            panel.SetActive(true); // Show menu
        }
        else {
            isPaused = false;
            Time.timeScale = 1;
            // This is what we want to do when the game is resumed
            panel.SetActive(false); // Hide menu
        }
    }

}
