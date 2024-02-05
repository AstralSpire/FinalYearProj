using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RunnerPlayer : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 5f;
    public float horiSpeed = 5f;
    public PlatformScript platformScript;
    public TextMeshProUGUI scoreNum;

    private float score = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * horiSpeed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("ArcadeRoom");
        }
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
            collision.gameObject.SetActive(false);
            speed++;
            score++;
            scoreNum.text = score.ToString();
            Debug.Log(score);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Trigger")
        {
            Debug.Log("it works");
            platformScript.GroundMove();
        }
    }
}