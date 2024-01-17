using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MazePlayer : MonoBehaviour
{
    private Vector2 PlayerMouseInput;
    private float xRot;
    [SerializeField] private float Sensitivity;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float turnSpeed = 45f;
    public Camera PlayerCamera;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        PlayerMouse();
        var velocity = Vector3.forward * Input.GetAxis("Vertical") * speed;
        transform.Translate(velocity * Time.deltaTime);
        //transform.Rotate(Vector3.up, Input.GetAxis("Horizontal") * Time.deltaTime * turnSpeed);
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("ArcadeRoom");
        }
    }

    private void PlayerMouse()
    {
        xRot -= PlayerMouseInput.y * Sensitivity;
        xRot = Mathf.Clamp(xRot, -90, 90);
        transform.Rotate(0f, PlayerMouseInput.x * Sensitivity, 0f);
        PlayerCamera.transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Collectible")
        {
            Destroy(collision.gameObject);
        }
    }
}
