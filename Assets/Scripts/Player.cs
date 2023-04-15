using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    //speed section
    public float speed = 23.75f;


    //Adding Gravity section
    public float gravityModifier;
    public Vector3 velocity;
    
    //Controller & camera head 
    public CharacterController myController;
    public Transform myCameraHead;

    private float mouseSensitivity = 200f;
    private float cameraVerticalRotation;

    //bullet section
    public GameObject bullet;
    public Transform firingPosition;

    public GameObject bulletHole, muzzleFlash, waterLeak;

    private GameObject newbulletHole;


    //jumping section
    public float jumpHeight = 20f;
    private bool readyToJump;
    public Transform ground;
    public LayerMask groundLayer;
    public float groundDistance = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        CameraMovement();
        Shoot();
        Jump();
        
    }

    void Jump()
    {

        readyToJump = Physics.OverlapSphere(ground.position, groundDistance, groundLayer).Length > 0;
        //Debug.Log(readyToJump);
        if (Input.GetButtonDown("Jump") && readyToJump)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y) * Time.deltaTime;
        }

        myController.Move(velocity);
    }

    private void Shoot()
    {
        bool trigger = Input.GetMouseButtonDown(0);

        if (trigger)
        {
            //Create RayCast
            RaycastHit hit;

            if(Physics.Raycast(myCameraHead.position, myCameraHead.forward, out hit, 200f))
            {
                //Check the distance between myCameraHead and the ray hit
                if(Vector3.Distance(myCameraHead.position, hit.point) > 2f)
                {
                    //accuracy
                    firingPosition.LookAt(hit.point);

                    if (hit.collider.tag == "Shootable")
                    {
                        Debug.Log(hit.collider.tag);
                        GameObject newBullet = Instantiate(bulletHole, hit.point, Quaternion.LookRotation(hit.normal));
                    }

                    if (hit.collider.tag == "Ground")
                    {
                        Debug.Log(hit.collider.tag);
                        GameObject newWaterLeak = Instantiate(waterLeak, hit.point, Quaternion.LookRotation(hit.normal));
                    }

                }

                //Destroy enemies with Raycast instead of in game physics cos bullets way too fast (need to learn a work around, would like to use physics) 
                if(hit.collider.tag == "Enemy")
                {
                    Destroy(hit.collider.gameObject);
                }

                
            } else
            {
                firingPosition.LookAt(myCameraHead.position + (myCameraHead.forward * 50f));
            }


            //Create a new bullet everytime after shooting the last using instantiate
            Instantiate(bullet, firingPosition.position, firingPosition.rotation);
            Instantiate(muzzleFlash, firingPosition.position, firingPosition.rotation, firingPosition);
            
        }
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

        //Adding Gravity
        velocity.y += Physics.gravity.y * Mathf.Pow(Time.deltaTime, 2) * gravityModifier;

        if(myController.isGrounded)
        {
            velocity.y = Physics.gravity.y * Time.deltaTime;
        }
        
         
        myController.Move(velocity);
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
