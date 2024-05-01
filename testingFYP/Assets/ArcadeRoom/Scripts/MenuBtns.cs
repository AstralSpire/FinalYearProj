using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuBtns : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject HUD;
    public GameObject Bar;
    public TextMeshProUGUI BartenderText;
    public GameObject DrinkButton;
    public AudioMixer audioMixer;
   
    public Slider Volume;
    public GameObject NoThanks;

    public void Start()
    {
        audioMixer.SetFloat("volume", -20f);
        Volume.value = -20f;
    }
    public void Pause()
    {
        //PausePanel.SetActive(true); 
        HUD.SetActive(false);

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
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
    public void FullScreen(bool fullScreen)
    {
        Screen.fullScreen = fullScreen;
    }
    public void DrinkPls()
    {
        DrinkButton.SetActive(false);
        NoThanks.SetActive(false);
        BartenderText.text = "Sure thing!";
    }
    public void No()
    {
        NoThanks.SetActive(false);
        DrinkButton.SetActive(false);
        BartenderText.text = "No Problem, have a good day!";
    }
}
