using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 30);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, Space.World);
        
    }
}
