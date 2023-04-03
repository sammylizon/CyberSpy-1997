using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 23.75f;
    public CharacterController myController;
    public Transform myCameraHead;

    private float mouseSensitivity = 850f;
    private float cameraVerticalRotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        CameraMovement();


    }

    void Movement()
    {
        //Get input for x and y axis 
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        //Create variable 'move' of Vector3 type and store the movement code 
        Vector3 move = transform.forward * y + transform.right * x;

        //Make the player move and multiply by Speed and deltaTime to make it smooth across systems
        myController.Move(move * speed * Time.deltaTime);
    }

    void CameraMovement()
    {
        //Get mouse x and y input anf multiply it by sensitivity and time delta 
        float mouseX = Input.GetAxisRaw("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //invert because Unity registers looking down as postive and looking up as negative whereas up is positive.
        cameraVerticalRotation -= mouseY;
        cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -90f, 90f);

        //Rotate the camera left and rigth 
        transform.Rotate(Vector3.up * mouseX);

        //Rotate the camera up and down independent of the body 
        myCameraHead.localRotation = Quaternion.Euler(cameraVerticalRotation, 0f, 0f);
    }
}
