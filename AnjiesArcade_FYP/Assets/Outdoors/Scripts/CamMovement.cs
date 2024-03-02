using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    public AnimationScript triggercheck;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float turnSpeed = 45f;
    public GameObject menuPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var velocity = Vector3.forward * Input.GetAxis("Vertical") * speed;
        transform.Translate(velocity * Time.deltaTime);
        transform.Rotate(Vector3.up, Input.GetAxis("Horizontal") * Time.deltaTime * turnSpeed);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Door")
        {
            triggercheck.PauseOn();
            //menuPanel.SetActive(true);
        }
        else
        {
            triggercheck.PauseOff();
            //menuPanel.SetActive(false) ;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
