using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    public float speed = 15f;
    public Rigidbody myRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        bool trigger = Input.GetButton("Fire1");

        if (trigger)
        {
            myRigidBody.AddForce(Vector3.forward * speed);
            Debug.Log(trigger);
        }
    }
}
