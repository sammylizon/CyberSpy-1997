using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    public float speed = 150f;
    public Rigidbody myRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BulletVelocity();
    }

    private void BulletVelocity()
    {
        myRigidBody.velocity = transform.forward * speed;
        
    }
}
