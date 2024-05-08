using UnityEngine;
using UnityEngine.UI;
public class VolumePanel : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject volumeMenu;
    public GameObject returnButton;
    private bool isVolumeMenuOpen = false;
    

    public Button pauseButton;

    

    void Start()
    {
        volumeMenu.SetActive(false);
        returnButton.SetActive(false);
    }
    void Update()
    {
        if (isVolumeMenuOpen)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                
                ReturnToGame();
            }
        }
    }
    public void ToggleVolumeMenu()
    {
        isVolumeMenuOpen = !isVolumeMenuOpen;
        volumeMenu.SetActive(isVolumeMenuOpen);
        if (isVolumeMenuOpen)
        {
            pauseButton.interactable = false;
            pauseMenu.SetActive(false);
            returnButton.SetActive(true);
        }
        else
        {
            pauseButton.interactable = true;
            pauseMenu.SetActive(true);
            returnButton.SetActive(false);
        }
    }
    

    public void ReturnToPauseMenu()
    {
        volumeMenu.SetActive(false);
        pauseMenu.SetActive(true);
        returnButton.SetActive(false);
        pauseButton.interactable = true;
        isVolumeMenuOpen = false;
    }
    public void ReturnToGame()
    {
        volumeMenu.SetActive(false);
        returnButton.SetActive(false);
        pauseButton.interactable = true;
       
    }

    
}