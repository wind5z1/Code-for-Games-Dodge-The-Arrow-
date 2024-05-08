using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class arrowgenerator : MonoBehaviour
{
    public GameObject arrowPrefab;
    float span = 1.0f;
    float delta = 0;
    float maxSpeed = 0.2f;
    float minSpan = 0.6f;
    private TimerManager timerManager;
    private float totalElapsedTime = 0f;
    private bool generateArrows = true;

    private static arrowgenerator instance;
   
    // Start is called before the first frame update
    private void Start()
    {

        timerManager = TimerManager.instance;
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

    public void ToggleArrowGeneration(bool enable)
    {
        generateArrows = enable;
    }

    private void OnSceneUnloaded(Scene scene)
    {
        generateArrows = false;
    }

    private void OnSceneLoaded(Scene scene,LoadSceneMode mode)
    {
        if(scene.name == "SampleScene")
        {
            ToggleArrowGeneration(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!generateArrows) return;

        this.delta += Time.deltaTime;
        float normalizedTime = Mathf.Clamp01(this.delta / maxSpeed);
        this.span = Mathf.Lerp(minSpan,maxSpeed,normalizedTime);

        if (this.delta > this.span)
        {
            this.delta = 0;

            

            float px = Random.Range(-6f,7f);
            float py = 7f;

            
            GameObject go = Instantiate(arrowPrefab);
            
            go.transform.position = new Vector3(px, py, 0);

          
        }

        totalElapsedTime += Time.deltaTime;

        if(totalElapsedTime >= 1200f)
        {
            maxSpeed = 0.1f;
            minSpan = 0.3f;
        }
    }
    private void OnDestroy()
    {
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }



}