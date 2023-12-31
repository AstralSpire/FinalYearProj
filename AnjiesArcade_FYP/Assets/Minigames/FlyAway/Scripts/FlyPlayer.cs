using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyPlayer : MonoBehaviour
{
    public float speed = 20f;
    
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        
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

}
