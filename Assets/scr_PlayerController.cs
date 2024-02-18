using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class scr_PlayerController : MonoBehaviour
{
    public Rigidbody rbSelf;
    public Transform cameraTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) == true)
        {
            rbSelf.AddForce(Vector3.forward);
        }
        if (Input.GetKey(KeyCode.S) == true)
        {
            rbSelf.AddForce(Vector3.back);
        }
        if (Input.GetKey(KeyCode.A) == true)
        {
            rbSelf.AddForce(Vector3.left);
        }
        if (Input.GetKey(KeyCode.D) == true)
        {
            rbSelf.AddForce(Vector3.right);
        }

        transform.localEulerAngles = new Vector3(0,cameraTransform.rotation.y,0);
    }
}
