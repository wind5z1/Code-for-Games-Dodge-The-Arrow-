using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Collections;
public class LoadingManager : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider loadingSlider;
    private bool isLoading = false;
    public void StartLoading(string sceneToLoad)
    {
        if (!isLoading)
        {
            isLoading = true;
            Time.timeScale = 1;
            loadingScreen.SetActive(true);
            StartCoroutine(LoadSceneAsync(sceneToLoad));
            
        }
    }
    IEnumerator LoadSceneAsync(string sceneToLoad)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneToLoad);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 1.0f);
            loadingSlider.value = progress;
            yield return null;
        }

        loadingScreen.SetActive(false);
        
    }
}