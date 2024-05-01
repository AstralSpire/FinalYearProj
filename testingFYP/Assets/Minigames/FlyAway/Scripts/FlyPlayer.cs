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
    public TextMeshProUGUI scoreNum;
    private int scoreCounter;
    public GameObject deathPanel;
    public GameObject startPanel;
    //public GameObject pausePanel;
    public ButtonFuncs pause;
    public GameObject Coin;
    public GameObject Enemy;
    public Transform EnemySpawn;
    public TextMeshProUGUI loseScore;
    public AudioSource coin , fish;

    // Start is called before the first frame update
    void Start()
    {
        startPanel.SetActive(true);
        Time.timeScale = 0.0f;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreCounter >= 5)
        {
            scoreCounter = 0;
            Debug.Log("sPAWNED DOOG");
            Instantiate(Enemy, EnemySpawn.position, Quaternion.identity);
        }

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
           // Destroy(collision.gameObject);
            if (Health <= MaxHealth)
            {
                fish.Play();
                Destroy(collision.gameObject);
                Health++;
            }
            else
            {
                Debug.Log("max health reached");
            }    
            healthNum.SetText(Health.ToString());
        }
        if(collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
            SpawnCoin();
            coin.Play();
            score++;
            scoreCounter++;
            scoreNum.text = score.ToString();
        }


    }
   
    public void SpawnCoin()
    {
        Instantiate(Coin, new Vector3(randomNumX(), randomNumY(), 1), Quaternion.identity);    
    }

    private void Death()
    {   
        deathPanel.SetActive(true);
        loseScore.text = "Score: " + score.ToString();
        Time.timeScale = 0;       
    }

    public int randomNumX()
    {
        int randNum = Random.RandomRange(-33, 38);
        return randNum;
    }
    public int randomNumY()
    {
        int randNum = Random.RandomRange(-10, 14);
        return randNum;
    }

    public void StartPanel()
    {
        startPanel.SetActive(false);
    }
}
