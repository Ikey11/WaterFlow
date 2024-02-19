using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class scr_GrabbableController : MonoBehaviour
{
    public Rigidbody rbSelf;
    public Transform cameraBody;
    public bool grabbed;
    public float distance = 1.2f;
    public float adjustSpeed = 10f;
    Vector3 goal;

    // Start is called before the first frame update
    void Start()
    {
        grabbed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (grabbed)
        {
            rbSelf.useGravity = false;
            goal = cameraBody.position + new Vector3(cameraBody.forward.x * distance, cameraBody.forward.y * distance, cameraBody.forward.z * distance);
            Debug.Log("Getting grabbed! " + Vector3.Lerp(transform.position, goal, adjustSpeed * Time.deltaTime) + "/" + goal);
            transform.position = Vector3.Lerp(transform.position, goal, adjustSpeed * Time.deltaTime);
            //transform.position = Vector3.MoveTowards(transform.position, goal, adjustSpeed * Time.deltaTime);
            //transform.position = goal;
        }
        else 
        {
            rbSelf.useGravity = true;
        }

    }

    public void grabStatusUpdate(Transform cam, bool status)
    {
        grabbed = status;
        cameraBody = cam;
    }
}
