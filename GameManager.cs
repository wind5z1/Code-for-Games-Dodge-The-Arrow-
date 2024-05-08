using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button exitButton;

    // Start is called before the first frame update
    void Start()
    {
        exitButton.onClick.AddListener(QuitGame);
    }

    // Update is called once per frame
    public void QuitGame()
    {
        Application.Quit();
    }
}
