using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public Scrollbar volumeScrollbar;
    public AudioSource audioSource;
   

    // Start is called before the first frame update
    void Start()
    {
        volumeScrollbar.value = audioSource.volume;
       
    }

    // Update is called once per frame
    public void AdjustVolume()
    {
        audioSource.volume = volumeScrollbar.value;

    }
}
