using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 23.75f;
    public CharacterController myController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        
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
}
