using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBtns : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject HUD;
    public GameObject Bar;
    public TextMeshProUGUI BartenderText;
    public GameObject DrinkButton;
    public GameObject NoThanks;

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
