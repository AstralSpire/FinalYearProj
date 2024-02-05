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
    public TextMeshProUGUI interact;
    private bool Maze , Fly , Run;

    // Start is called before the first frame update
    void Start()
    {
        Fly = false;
        interact.gameObject.SetActive(false);
        animator = GetComponent<Animator>();       
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
            Debug.Log("mazeWorks");
            interact.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                SceneManager.LoadScene("Maze");
            }
        }
        else if (collision.gameObject.tag == "Runner")
        {
            Debug.Log("runWorks");
            interact.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                SceneManager.LoadScene("Runner");
            }
        }
        else
        {
            Fly = false;
            //interact.gameObject.SetActive(false);
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
        
    }
}
