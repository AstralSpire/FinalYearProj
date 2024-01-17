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


    // Start is called before the first frame update
    void Start()
    {
        //interact.gameObject.SetActive(false);
        animator = GetComponent<Animator>();       
    }

    // Update is called once per frame
    void Update()
    {
        var velocity = Vector3.forward * Input.GetAxis("Vertical") * speed;
        transform.Translate(velocity * Time.deltaTime);
        transform.Rotate(Vector3.up, Input.GetAxis("Horizontal") * Time.deltaTime * turnSpeed);
        animator.SetFloat("speed", velocity.z);

        //Testing purposes
        if (Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadScene("FlyAway!");
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            SceneManager.LoadScene("Maze");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Runner");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if(collision.gameObject.tag == "FlyAway")
        //{
        //    Debug.Log("flyWorks");
        //    interact.gameObject.SetActive(true);
        //    if (Input.GetKeyDown(KeyCode.F))
        //    {
        //        SceneManager.LoadScene("FlyAway");
        //    }

        //}
        //if (collision.gameObject.tag == "Maze")
        //{
        //    interact.gameObject.SetActive(true);
        //    if (Input.GetKeyDown(KeyCode.F))
        //    {
        //        SceneManager.LoadScene("Maze");
        //    }
        //}
        //if (collision.gameObject.tag == "Runner")
        //{
        //    interact.gameObject.SetActive(true);
        //    if (Input.GetKeyDown(KeyCode.F))
        //    {
        //        SceneManager.LoadScene("Runner");
        //    }
        //}
        //else
        //{
        //    interact.gameObject.SetActive(false);
        //}
    }
}
