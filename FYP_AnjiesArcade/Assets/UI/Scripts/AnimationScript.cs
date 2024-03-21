using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    [SerializeField] GameObject panel;
    public GameObject offScreenLoc;
    public GameObject OnScreenLoc;
    private bool isPaused;

    // Start is called before the first frame update

    public void Start()
    {
        
    }

    public void Update()
    {
        if (isPaused)
        {
           float posY = Mathf.Lerp(panel.transform.position.y, OnScreenLoc.transform.position.y, 5 * Time.unscaledDeltaTime);
            panel.transform.position = new Vector3(panel.transform.position.x, posY, panel.transform.position.z);
         
        }
        else
        {
            float posY = Mathf.Lerp(panel.transform.position.y, offScreenLoc.transform.position.y, 5 * Time.unscaledDeltaTime);
            panel.transform.position = new Vector3(panel.transform.position.x, posY, panel.transform.position.z);

        }

    }
    public void PauseOn()
    {
       isPaused = true;
    }

    public void PauseOff()
    {
        isPaused = false;
       
    }
}
