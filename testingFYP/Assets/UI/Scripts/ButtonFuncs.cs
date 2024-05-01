using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonFuncs : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject DeathPanel;
    public GameObject HUD;
    public string SceneLoad;
    public AudioMixer audioMixer;
    public Slider Volume;
    // Start is called before the first frame update
    public void Start()
    {
        audioMixer.SetFloat("volume", -20f);
        Volume.value = -20f;
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
        //PausePanel.SetActive(false); 
        HUD.SetActive(true);
        
    }
    

    public void Quit1()
    {
        
        SceneManager.LoadScene("Menu");
    }
    public void deathPanelFalse()
    {
        DeathPanel.SetActive(false);
    }
    public void timeStop()
    {
        Time.timeScale = 0.0f;
    }
    public void timeStart()
    {
        Time.timeScale = 1f;
    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
    public void FullScreen(bool fullScreen)
    {
        Screen.fullScreen = fullScreen;
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
  
