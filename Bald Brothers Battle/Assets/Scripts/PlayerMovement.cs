using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int playerIndex;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float lookSensitivityH = 2f;
    [SerializeField] private float lookSensitivityV = 2f;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private Camera cam;
    private Rigidbody rb;
    private float yaw = 0.0f;
    private float pitch = 0.0f;
    private float pitchClampUp = -25;
    private float pitchClampDown = 15;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }


    void Update()
    {
        if (TurnManager.GetInstance().PlayerIsActive(playerIndex))
        {
            MouseRotation();

            if (Input.GetButtonDown("Jump") && IsGrounded())
            {
                rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            }

            float leftRight = Input.GetAxisRaw("Horizontal");
            float forwardBack = Input.GetAxisRaw("Vertical");

            Vector3 playerMovement = new Vector3(leftRight, 0, forwardBack).normalized;
            rb.transform.Translate(moveSpeed * Time.deltaTime * playerMovement);
        }
    }


    public bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, 0.1f, whatIsGround);
    }

    private void MouseRotation()
    {
        yaw += lookSensitivityH * Input.GetAxis("Mouse X");
        pitch -= lookSensitivityV * Input.GetAxis("Mouse Y");
        pitch = Mathf.Clamp(pitch, pitchClampUp, pitchClampDown);

        cam.transform.localEulerAngles = new Vector3(pitch, 0.0f, 0.0f);
        transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);
    }

}

    

