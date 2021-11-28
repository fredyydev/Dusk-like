using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public CharacterController controller;
    [SerializeField] Camera fpsCamera;
    
    public float movementSpeed = 10f;
    public float sensitivity = 100f;
    [HideInInspector] public bool isMoving;
    [HideInInspector] public float mouseX, mouseY;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void MoveChar(Vector2 horizontal_movement, float up_movement = 0f)
    {
        horizontal_movement = horizontal_movement.normalized;
        Vector3 movement = new Vector3(horizontal_movement.x * movementSpeed, up_movement, horizontal_movement.y * movementSpeed);

        controller.Move(movement * Time.deltaTime);
    }

    private void Update()
    {
        isMoving = Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0;

        CameraLook();
    }

    public void CameraLook()
    {
        //Setup mouse inputs.
        mouseX += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        mouseY -= Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        mouseY = Mathf.Clamp(mouseY, -80f, 80f);

        Vector3 eulerInput = new Vector3(mouseY, mouseX, 0);

        transform.eulerAngles = eulerInput;
        fpsCamera.transform.rotation = Quaternion.Euler(eulerInput);
       
    }
}
