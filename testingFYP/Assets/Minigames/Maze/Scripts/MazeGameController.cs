using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGameController : MonoBehaviour
{
    //UI OBJECTS
    public GameObject PausePanel;
    public GameObject HUD;
    public GameObject Instruc;
    public GameObject PlayBtn;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        //PausePanel.SetActive(false);
        HUD.SetActive(false);
        Instruc.SetActive(true);
        PlayBtn.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        HUD.SetActive(true);
        Instruc.SetActive(false);
        PlayBtn.SetActive(false);
    }
}
