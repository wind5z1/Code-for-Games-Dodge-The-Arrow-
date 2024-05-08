using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip menuOpenSound;
    public AudioClip menuCloseSound;

    private bool isMenuOpen = false;

   public void PlayMenuSound()
    {
        if(menuOpenSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(menuOpenSound);
        }
    }

    public void StopMenuSound()
    {
        if(audioSource != null)
        {
            audioSource.Stop();
        }
    }

    public void PlayMenuCloseSound()
    {
        if(menuCloseSound!= null && audioSource!= null)
        {
            audioSource.PlayOneShot(menuCloseSound);
        }
    }
     void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isMenuOpen)
            {
                isMenuOpen = false;
                StopMenuSound();
                PlayMenuCloseSound();
            }
            else
            {
                PlayMenuSound();
                isMenuOpen = true;
            }
           
        }
    }
}
