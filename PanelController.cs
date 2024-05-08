using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{

    public GameObject panel;

    void Start()
    {
        panel.SetActive(false);     
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)&& panel.activeSelf)
        {
            ClosePanel();
        }
    }

    // Update is called once per frame
    public void TogglePanel()
    {
        panel.SetActive(!panel.activeSelf);
    }

    public void ClosePanel()
    {
        panel.SetActive(false);
    }
}
