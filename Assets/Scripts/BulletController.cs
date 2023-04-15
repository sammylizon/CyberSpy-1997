using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    public float speed = 500f;
    public Rigidbody myRigidBody;
    public float bulletLife; 
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BulletVelocity();
        bulletLife -= Time.deltaTime;

        if(bulletLife < 0)
        {
            Destroy(gameObject);
        }
    }

    private void BulletVelocity()
    {
        myRigidBody.velocity = transform.forward * speed;
        
    }

    private void OnTriggerEnter(Collider other)
    {
      
        Destroy(gameObject);
    }
}
