using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameDirector : MonoBehaviour
{
    private Image hpGauge;
    private float initialHpAmount;
    private bool isGameOver = false;
    private Image playerImage;
    private float immunityDuration = 5.0f;
    private float immunityTimer = 0.0f;
    private bool isPlayerImmune = false;
    public TMP_Text immunityTimerText;
    

    public static bool IsGameOver
    {
        get { return instance.isGameOver; }
    }

    private static GameDirector instance;

    private void Awake()
    {

        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            ResetImmunityTimer();
            immunityTimerText = GameObject.Find("Immunity")?.GetComponent<TMP_Text>();
        }

    }


    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // Start is called before the first frame update
    void Start()
    {
        InitializeHpGauge();
        playerImage = GameObject.Find("player")?.GetComponent<Image>();
    }

    private void InitializeHpGauge()
    {
        hpGauge = GameObject.Find("hpGauge")?.GetComponent<Image>();

        if (hpGauge != null)
        {
            initialHpAmount = hpGauge.fillAmount;
            SetHpGauge(initialHpAmount);
        }


    }

    // Update is called once per frame
    public void DecreaseHp()
    {
        if (!IsGameOver && hpGauge != null && !IsPlayerImmune())
        {
            hpGauge.GetComponent<Image>().fillAmount -= 0.1f;

            if (hpGauge.GetComponent<Image>().fillAmount <= 0f)
            {
                isGameOver = true;

                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }



    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        isGameOver = false;
        InitializeHpGauge();
        ResetImmunityTimer();
        immunityTimerText = GameObject.Find("Immunity")?.GetComponent<TMP_Text>();
    }

    private void SetHpGauge(float value, Image image = null)
    {
        if (image == null)
        {
            image = hpGauge;
        }

        if (image != null)
        {
            image.fillAmount = value;
        }
    }

    

   

    public void ActiveImmunity(float duration)
    {
        isPlayerImmune = true;
        StartCoroutine(ImmunityTimer(duration));
        
    }

    private IEnumerator ImmunityTimer(float duration)
    {

        if (playerImage != null)
        {
            playerImage.enabled = false;
        }

        immunityTimer = duration;
        while (immunityTimer > 0.0f)
        {
            UpdateImmunityTimerText();
            yield return new WaitForSeconds(duration);
            immunityTimer -= 0.1f;
        }

        immunityTimer = 0.0f;

        if (playerImage != null)
        {
            playerImage.enabled = true;
        }
        isPlayerImmune = false;
        UpdateImmunityTimerText();

        
    }
    public bool IsPlayerImmune()
    {
        return immunityTimer > 0.0f;
    }

    private void UpdateImmunityTimerText()
    {
        if (immunityTimerText != null && IsPlayerImmune())
        {
            immunityTimerText.text = "Immunity: " + immunityTimer.ToString("F1") + "s";
        }
        else if (immunityTimerText != null)
        {
            immunityTimerText.text = " ";
        }
    }
    private void ResetImmunityTimer()
    {
        isPlayerImmune = false;
        immunityTimer = 0.0f;
        if (playerImage != null)
        {
            playerImage.enabled = true;
        }
        UpdateImmunityTimerText();
    }

    
}