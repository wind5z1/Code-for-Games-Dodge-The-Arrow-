using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Meatgenerator : MonoBehaviour
{
    public GameObject meatPrefab;
    public ScoreManager scoreManager;
    float span = 5.0f;
    float delta = 0;
    private bool generateMeat = true;
    private static Meatgenerator instance;
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

    public void ToggleMeatGenerator(bool enable)
    {
        generateMeat = enable;
    }

    public void OnSceneUnloaded(Scene scene)
    {
        generateMeat = false;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "SampleScene")
        {
            ToggleMeatGenerator(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!generateMeat) return;
        
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            GameObject go = Instantiate(meatPrefab);
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
