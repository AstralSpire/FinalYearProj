using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFuncs : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject HUD;
    public string SceneLoad;
    // Start is called before the first frame update
    public void Start()
    {
        
    }
    public void Play()
    {
        SceneManager.LoadScene(SceneLoad);
    }

    public void Lobby()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("ArcadeRoom");
    }
    public void Pause()
    {
        PausePanel.SetActive(true); HUD.SetActive(false);
        Time.timeScale = 0.0f;
    }
    public void Resume()
    {
        PausePanel.SetActive(false); HUD.SetActive(true);
        Time.timeScale = 1.0f;
    }

    public void Quit1()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
