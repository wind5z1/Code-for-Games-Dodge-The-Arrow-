using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public Text scoreText;
    public GameObject loadingUI;
    public Slider loadingProgressBar;
    GetData data;

    void Start()
    {
        this.scoreText = GameObject.Find("Text").GetComponent<Text>();
        UpdateScoreText();
        OnTapGet();
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


    public void OnTapGet()
    {
        StartCoroutine(SendGetMessage("http://localhost:8088/score"));
    }

    IEnumerator SendGetMessage(string uri)
    {
        UnityWebRequest uwr = UnityWebRequest.Get(uri);
        yield return uwr.SendWebRequest();

        if(uwr.result == UnityWebRequest.Result.ConnectionError || uwr.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError(uwr.error);
        }
        else
        {
            Debug.Log(uwr.downloadHandler.text);

            data = JsonUtility.FromJson<GetData>(uwr.downloadHandler.text);
        }
    }

}

public class GetData
{
    public Data[] highscore;
}

public class Data
{
    public int score;
    public string user;
}
