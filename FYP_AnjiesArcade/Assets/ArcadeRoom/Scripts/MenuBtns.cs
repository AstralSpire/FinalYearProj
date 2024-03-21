using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBtns : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject HUD;

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
}
