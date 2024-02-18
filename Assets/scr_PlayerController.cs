using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class scr_PlayerController : MonoBehaviour
{
    public Rigidbody rbSelf;
    public float moveSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.localEulerAngles = new Vector3(0, cameraTransform.rotation.y, 0);

        float forwardMovement = Input.GetAxis("Vertical");
        float sideMovement = Input.GetAxis("Horizontal");

        /***
        if (Input.GetKey(KeyCode.W) == true)
        {
            //new Vector3(transform.rotation.y / 90,0,1 - transform.rotation.y / 90);
            forwardMovement += ;
            rbSelf.AddForce(-1 * transform.forward);
        }
        if (Input.GetKey(KeyCode.S) == true)
        {
            rbSelf.AddForce(transform.forward);
        }
        if (Input.GetKey(KeyCode.A) == true)
        {
            rbSelf.AddForce(-1*transform.right);
        }
        if (Input.GetKey(KeyCode.D) == true)
        {
            rbSelf.AddForce(transform.right);
        }
        ***/

        Vector3 movedirection = forwardMovement * transform.forward + sideMovement * transform.right;
        rbSelf.AddForce(movedirection * moveSpeed,ForceMode.Force);
        //rbSelf.GetAccumulatedForce;
    }
}
