using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
//using UnityEngine.UIElements;

public class scr_PlayerController : MonoBehaviour
{
    public Rigidbody rbSelf;
    public float moveSpeed = 2.5f;
    public float maxSpeed = 5f;
    public Transform cameraBody;
    public GameObject grabObject = null;
    float prevFM;
    float prevSM;
    float forwardMovement;
    float sideMovement;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;

        prevFM = 0f;
        prevSM = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.localEulerAngles = new Vector3(0, cameraTransform.rotation.y, 0);

        forwardMovement = Input.GetAxis("Vertical");
        sideMovement = Input.GetAxis("Horizontal");

        /**
        if (prevFM < forwardMovement && prevSM < sideMovement)
        {
            rbSelf.AddForce(-rbSelf.GetAccumulatedForce());
        }
        else
        {
        **/

        /**
        Vector3 movedirection = forwardMovement * transform.forward + sideMovement * transform.right;
        //if(rbSelf.GetAccumulatedForce().x + rbSelf.GetAccumulatedForce().y < maxSpeed)
        rbSelf.AddForce(movedirection.normalized * moveSpeed, ForceMode.Force);
        //}

        prevFM = forwardMovement;
        prevSM = sideMovement;
        **/

        if (grabObject != null)
        {
            if (grabObject.GetComponent<scr_GrabbableController>().grabbed == false)
            {
                Debug.Log("Object dropped!");
                grabObject = null;
            }
        }

            if (Input.GetMouseButtonDown(0))
        {
            if (grabObject == null)
            {
                pickUp();
            }
            else
            {
                dropOff();
            }

        }

        //Debug.Log(rbSelf.GetAccumulatedForce() + "," + forwardMovement);
    }

    private void FixedUpdate()
    {
        Vector3 movedirection = forwardMovement * transform.forward + sideMovement * transform.right;
        //if(rbSelf.GetAccumulatedForce().x + rbSelf.GetAccumulatedForce().y < maxSpeed)
        rbSelf.AddForce(movedirection.normalized * moveSpeed, ForceMode.Force);
        //}

        prevFM = forwardMovement;
        prevSM = sideMovement;
    }

    void pickUp()
    {
        RaycastHit ray;
        int layerMask = 1 << 6;
        Debug.Log("scr_PlayerController: Attempting interact, " + cameraBody.forward);
        if (Physics.Raycast(cameraBody.position, cameraBody.forward, out ray, 100f, layerMask))
        {
            //if (ray.transform) { }
            GameObject item = ray.transform.gameObject;
            Debug.Log("scr_PlayerController: Item Found");
            if (item.tag == "Grabbable")
            {
                Debug.Log("scr_PlayerController: Attempting to Grab!");
                item.GetComponent<scr_GrabbableController>().grabStatusUpdate(cameraBody, true);
                grabObject = item;
            }
            else if (item.tag == "Switch")
            {
                Debug.Log("scr_PlayerController: Attempting to switch!");
                item.GetComponent<scr_SwitchController>().ToggleSwitch();
            }
        }
        //Debug.DrawRay(cameraBody.position, cameraBody.forward, Color.green, 100f);
    }
    
    void dropOff()
    {
        grabObject.GetComponent<scr_GrabbableController>().grabbed = false;
        grabObject = null;
    }

    void OnTriggerEnter(Collider thing)
    {
        if(thing.tag == "Exit")
        {
            thing.GetComponent<scr_exitScene>().changeScene();
        }
        else if(thing.tag == "death zone")
        {
            //Debug.Log("Entered death plane");
            thing.GetComponent<scr_DeathPlane>().respawn(transform);
        }
    }

}
