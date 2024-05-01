using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float turnSpeed = 45f;
    private Animator animator;
    public GameObject interact;
    private bool Maze , Fly , Run, Bar;
    public GameObject Fade;
    public GameObject BarText;

    // Start is called before the first frame update
    void Start()
    {
        Fade.SetActive(true);
        Time.timeScale = 1;
        Fly = false;
        BarText.gameObject.SetActive(false);
        interact.gameObject.SetActive(false);
        animator = GetComponent<Animator>();
        //Cursor.lockState = CursorLockMode.Locked; Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        var velocity = Vector3.forward * Input.GetAxis("Vertical") * speed;
        transform.Translate(velocity * Time.deltaTime);
        transform.Rotate(Vector3.up, Input.GetAxis("Horizontal") * Time.deltaTime * turnSpeed);
        animator.SetFloat("speed", velocity.z);

        if (Fly && Input.GetKey(KeyCode.F)) 
        {
            SceneManager.LoadScene("FlyAway!");
        }
        if (Run && Input.GetKey(KeyCode.F))
        {
            SceneManager.LoadScene("Runner");
        }
        if (Maze && Input.GetKey(KeyCode.F))
        {
            SceneManager.LoadScene("Maze");
        }
        if(Bar && Input.GetKey(KeyCode.F))
        {
            BarText.gameObject.SetActive(true);
            interact.gameObject.SetActive(false);
        }

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "FlyAway")
        {
            Fly = true;
            Debug.Log("flyWorks");
            interact.gameObject.SetActive(true);
            

        }
        else if (collision.gameObject.tag == "Maze")
        {
            Maze = true;
            Debug.Log("mazeWorks");
            interact.gameObject.SetActive(true);
            
        }
        else if (collision.gameObject.tag == "Runner")
        {
            Run = true;
            Debug.Log("runWorks");
            interact.gameObject.SetActive(true);
            
        }
        else if (collision.gameObject.tag == "Bar")
        {
            //interact.gameObject.SetActive(true);   
            BarText.gameObject.SetActive(true);
        }
        else
        {
            Run = false;
            Maze = false;
            Fly = false;
            Bar = false;
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "FlyAway")
        {
            interact.gameObject.SetActive(false);
        }
        if (other.gameObject.tag == "Maze")
        {
            interact.gameObject.SetActive(false);
        }
        if (other.gameObject.tag == "Runner")
        {
            interact.gameObject.SetActive(false);
        }
        if (other.gameObject.tag == "Bar")
        {
            //interact.gameObject.SetActive(false);
            BarText.gameObject.SetActive(false);
        }

    }
}
