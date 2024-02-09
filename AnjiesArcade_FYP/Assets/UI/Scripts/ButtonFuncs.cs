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
        
        SceneManager.LoadScene("ArcadeRoom");
    }
    public void Pause()
    {
        PausePanel.SetActive(true); HUD.SetActive(false);
        
    }
    public void Resume()
    {
        PausePanel.SetActive(false); HUD.SetActive(true);
        
    }
    

    public void Quit1()
    {
        
        SceneManager.LoadScene("Menu");
    }
    public void timeStop()
    {
        Time.timeScale = 0.0f;
    }
    public void timeStart()
    {
        Time.timeScale = 1f;
    }
    public void MenuQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
