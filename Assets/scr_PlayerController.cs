using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class scr_PlayerController : MonoBehaviour
{
    public Rigidbody rbSelf;
    public float moveSpeed = 2.5f;
    public float maxSpeed = 5f;
    public Transform cameraBody;
    float prevFM;
    float prevSM;

    // Start is called before the first frame update
    void Start()
    {
        prevFM = 0f;
        prevSM = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.localEulerAngles = new Vector3(0, cameraTransform.rotation.y, 0);

        float forwardMovement = Input.GetAxis("Vertical");
        float sideMovement = Input.GetAxis("Horizontal");

        /**
        if (prevFM < forwardMovement && prevSM < sideMovement)
        {
            rbSelf.AddForce(-rbSelf.GetAccumulatedForce());
        }
        else
        {
        **/
        Vector3 movedirection = forwardMovement * transform.forward + sideMovement * transform.right;
        //if(rbSelf.GetAccumulatedForce().x + rbSelf.GetAccumulatedForce().y < maxSpeed)
        rbSelf.AddForce(movedirection.normalized * moveSpeed, ForceMode.Force);
        //}

        prevFM = forwardMovement;
        prevSM = sideMovement;

        if (Input.GetMouseButtonDown(0))
        {
            pickUp();
        }

        //Debug.Log(rbSelf.GetAccumulatedForce() + "," + forwardMovement);
    }

    void pickUp()
    {
        RaycastHit ray;
        Debug.Log("Attempting pickup");
        if (Physics.Raycast(cameraBody.position, transform.forward, out ray, 100f))
        {
            //if (ray.transform) { }
            GameObject item = ray.transform.gameObject;
            Debug.Log("object pick up attempted");
            if(item.tag == "Grabbable")
            {
                Debug.Log("This item should get picked up!");
            }
        }
    }
}
