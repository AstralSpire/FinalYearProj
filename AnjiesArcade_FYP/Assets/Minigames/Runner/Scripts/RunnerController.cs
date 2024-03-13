using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerController : MonoBehaviour
{
    public GameObject startPanel;

    // Start is called before the first frame update
    void Start()
    {
        startPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HidePanel()
    {
        startPanel.SetActive(false);
    }
}
