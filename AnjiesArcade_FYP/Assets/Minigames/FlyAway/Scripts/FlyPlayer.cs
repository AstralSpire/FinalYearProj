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
    public GameObject health;
    //testing purpose , add health bar later
    public TextMeshProUGUI healthNum;
    public GameObject deathPanel;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        Movement();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("ArcadeRoom");
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
            Health ++;
            healthNum.SetText(Health.ToString());
        }


    }
   

    private void Death()
    {   
        deathPanel.SetActive(true);
        Time.timeScale = 0;       
    }
}
