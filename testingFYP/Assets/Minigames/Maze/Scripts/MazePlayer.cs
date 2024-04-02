using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public GameObject WinnerPanel;
    public int score;
    public TextMeshProUGUI scoreTxt;
    // Start is called before the first frame update
    void Start()
    {
        WinnerPanel.SetActive(false);
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
            Cursor.lockState = CursorLockMode.None; Cursor.visible = true;
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
            score++;
            scoreTxt.text = score.ToString() + "/14"; 
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag == "Door")
        {
            WinnerPanel.SetActive(true);
            Debug.Log("Win works");
        }
    }
}
