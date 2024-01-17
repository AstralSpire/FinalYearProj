using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemy : MonoBehaviour
{
    public Transform targetPlayer;
    public float speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //var step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, targetPlayer.position, speed);
    }
}
