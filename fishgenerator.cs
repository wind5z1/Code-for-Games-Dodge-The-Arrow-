using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fishgenerator : MonoBehaviour
{
    public GameObject fishPrefab;
    public ScoreManager scoreManager;
    float span = 2.0f;
    float delta = 0;
    private bool generateFish = true;
    private static fishgenerator instance;
    // Start is called before the first frame update
    private void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        SceneManager.sceneUnloaded += OnSceneUnloaded;
        SceneManager.sceneLoaded += OnSceneLoaded;

    }

    public void ToggleFishGenerator(bool enable)
    {
        generateFish = enable;
    }

    public void OnSceneUnloaded(Scene scene)
    {
        generateFish = false;
    }

    private void OnSceneLoaded(Scene scene,LoadSceneMode mode)
    {
        if(scene.name == "SampleScene")
        {
            ToggleFishGenerator(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!generateFish) return;
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            GameObject go = Instantiate(fishPrefab);
            int px = Random.Range(-7, 8);
            go.transform.position = new Vector3(px, 7, 0);
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }




}
