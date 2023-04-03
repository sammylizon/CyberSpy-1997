using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    public Transform myPlayerHead;
   

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; 
    }

    //Late Update is called after all other updates have been made
    private void LateUpdate()
    {

        transform.rotation = myPlayerHead.rotation;
        transform.position = myPlayerHead.position;
        
    }
}
