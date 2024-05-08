using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public Text scoreText;
    public GameObject loadingUI;
    public Slider loadingProgressBar;

    void Start()
    {
        this.scoreText = GameObject.Find("Text").GetComponent<Text>();
        UpdateScoreText();
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();

        if(score >= 10000 )
        {
            loadingUI.SetActive(true);

            StartCoroutine(LoadTargetScene());
        }
        
        
    }

    private IEnumerator LoadTargetScene()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("gameoverscene2");

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 1.0f);
            loadingProgressBar.value = progress;

            yield return null;
        }
        loadingUI.SetActive(false);
    }

    void UpdateScoreText()
    {
        this.scoreText.text = "HighScore: " + score.ToString();
    }

   
}