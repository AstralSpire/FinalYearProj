using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RunnerPlayer : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 1f;
    public float horiSpeed = 5f;
    public PlatformScript platformScript;
    public TextMeshProUGUI scoreNum;
    public GameObject deathPanel;
    public AudioSource coin;

    private float score = 0;
    public TextMeshProUGUI WinScore;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("RunnerCurrentScore"))
        {
            PlayerPrefs.SetFloat("RunnerCurrentScore", score);
        }
        StartCoroutine(Timer());
        Debug.Log(PlayerPrefs.GetFloat("RunnerCurrentScore"));
        //Time.timeScale = 1f;    
    }

    // Update is called once per frame
    void Update()
    {
        

        //Debug.Log(speed);
        float horizontalInput = Input.GetAxis("Horizontal");
        
        Vector3 velocity = new Vector3(horiSpeed * horizontalInput, 0, speed);
        rb.MovePosition(rb.position + velocity * Time.deltaTime);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        //if(collision.gameObject.tag == "Trigger")
        //{
        //    Debug.Log("it works");
        //    platformScript.GroundMove();
        //}
        if(collision.gameObject.tag == "Collectible")
        {
            Destroy(collision.gameObject);
            coin.Play();
            score++;
            scoreNum.text = score.ToString();
            //Debug.Log(score);
        }
        if (collision.gameObject.tag == "Obstacle")
        {
            if (PlayerPrefs.HasKey("RunnerCurrentScore") && PlayerPrefs.GetFloat("RunnerCurrentScore") < score)
            {
                PlayerPrefs.SetFloat("RunnerCurrentScore", score);
            }
            //Debug.Log("works");
            deathPanel.SetActive(true);
            WinScore.text = "Score: " + score.ToString();
            Time.timeScale = 0f;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Trigger")
        {
            //Debug.Log("it works");
            platformScript.GroundMove();
        }
    }

    private IEnumerator Timer()
    {
        speed += 1f;
        yield return new WaitForSeconds(5);
        StartCoroutine(Timer());
    }
}
