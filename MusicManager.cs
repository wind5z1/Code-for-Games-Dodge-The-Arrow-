using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public AudioClip scene1Bgm;
    public AudioClip scene2Bgm;
    public AudioClip scene3Bgm;
    public AudioClip scene4Bgm;
    public AudioClip scene5Bgm;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene,LoadSceneMode mode)
    {
        switch (scene.name)
        {
            case "GameOverScene":
                PlayScene1BGM();
                break;
            case "SampleScene":
                PlayScene2BGM();
                break;
            case "gameoverscene2":
                PlayScene3BGM();
                break;
            case "instruction":
                PlayScene4BGM();
                break;
            case "GG":
                PlayScene5BGM();
                break;
        }
    }

    private void PlayScene1BGM()
    {
        audioSource.Stop();
        audioSource.clip = scene1Bgm;
        audioSource.Play();
    }

    private void PlayScene2BGM()
    {
        audioSource.Stop();
        audioSource.clip = scene2Bgm;
        audioSource.Play();
    }
    private void PlayScene3BGM()
    {
        audioSource.Stop();
        audioSource.clip = scene3Bgm;
        audioSource.Play();
    }
    private void PlayScene4BGM()
    {
        audioSource.Stop();
        audioSource.clip = scene4Bgm;
        audioSource.Play();
    }
    private void PlayScene5BGM()
    {
        audioSource.Stop();
        audioSource.clip = scene5Bgm;
        audioSource.Play();
    }
}
