using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    private Vector2 PlayerMouseInput;
    private float xRot;
    public Camera PlayerCamera;
    [SerializeField] private float Sensitivity;
    public AnimationScript triggercheck;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float turnSpeed = 45f;
    public GameObject menuPanel;
    public GameObject fade;
    // Start is called before the first frame update
    void Start()
    {
        fade.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked; Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        PlayerMouse();
        var velocity = Vector3.forward * Input.GetAxis("Vertical") * speed;
        transform.Translate(velocity * Time.deltaTime);
        //transform.Rotate(Vector3.up, Input.GetAxis("Horizontal") * Time.deltaTime * turnSpeed);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None; Cursor.visible = true;
        }
        //var velocity = Vector3.forward * Input.GetAxis("Vertical") * speed;
        //transform.Translate(velocity * Time.deltaTime);
        //transform.Rotate(Vector3.up, Input.GetAxis("Horizontal") * Time.deltaTime * turnSpeed);
    }
    private void PlayerMouse()
    {
        xRot -= PlayerMouseInput.y * Sensitivity;
        xRot = Mathf.Clamp(xRot, -90, 90);
        transform.Rotate(0f, PlayerMouseInput.x * Sensitivity, 0f);
        PlayerCamera.transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
    }
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Door")
        {
            triggercheck.PauseOn();
            Cursor.lockState = CursorLockMode.None; Cursor.visible = true;
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
