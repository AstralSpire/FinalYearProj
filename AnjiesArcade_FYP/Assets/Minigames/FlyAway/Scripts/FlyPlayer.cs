using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlyPlayer : MonoBehaviour
{
    public float speed = 20f;
    private float score = 0;
    private Rigidbody2D rb;
    private int Health = 3;
    private int MaxHealth = 2;
    public GameObject health;
    //testing purpose , add health bar later
    public TextMeshProUGUI healthNum;
    public GameObject deathPanel;
    //public GameObject pausePanel;
    public ButtonFuncs pause;
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        Movement();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause.Pause(); 
        }
        if(Health <= 0)
        {
            Death(); 
        }
    }

    private void FixedUpdate()
    {
       
    }

    private void Movement()
    {
        if(Input.GetKey(KeyCode.W))
        {
            Debug.Log("W works");
        }
        float _Hori = Input.GetAxis("Horizontal");
        float _Ver = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(_Hori, _Ver);
        rb.velocity = movement * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemies")
        {
            Health --;
            healthNum.SetText(Health.ToString());
        }
        if(collision.gameObject.tag == "Collectible")
        {
            Destroy(collision.gameObject);
            if (Health <= MaxHealth)
            {
                Health++;
            }
            else
            {
                Debug.Log("max health reached");
            }    
            healthNum.SetText(Health.ToString());
        }


    }
   

    private void Death()
    {   
        deathPanel.SetActive(true);
        Time.timeScale = 0;       
    }
}
