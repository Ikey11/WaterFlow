using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_InsertableController : MonoBehaviour
{
    public bool inserted = false;
    public string pipeType = "default";
    
    private Rigidbody rbSelf;
    private scr_GrabbableController GrabControl;
    Vector3 insertionLocation;

    void Awake()
    {
        rbSelf = gameObject.GetComponent<Rigidbody>();
        GrabControl = gameObject.GetComponent<scr_GrabbableController>();
    }

    void Update()
    {
        if (inserted && !GrabControl.grabbed)
        {
            transform.position = insertionLocation;
        }
    }

    void OnTriggerEnter(Collider thing)
    {
        Debug.Log("Entered trigger");
        if (GrabControl.grabbed && inserted == false && thing.tag == "PipeInsert") //When grabbed and put into a pipe insert
        {
            if (thing.GetComponent<scr_PipeInsertSpotControl>().filled == false)
            {
                Debug.Log("Begin lock!");
                inserted = true;
                GrabControl.grabbed = false;
                GrabControl.gravOn = false;
                transform.position = thing.transform.position;
                insertionLocation = thing.transform.position;
                thing.GetComponent<scr_PipeInsertSpotControl>().UpdateInsertion(pipeType);
                transform.localEulerAngles = thing.GetComponent<scr_PipeInsertSpotControl>().pipeRotation;
                rbSelf.freezeRotation = true;
                rbSelf.AddForce(-rbSelf.GetAccumulatedForce());
            }
        }
        else if (thing.tag == "death zone")
        {
            //Debug.Log("Entered death plane");
            thing.GetComponent<scr_DeathPlane>().respawn(transform);
        }
    }

    private void OnTriggerExit(Collider thing)
    {
        if (thing.tag == "PipeInsert" && inserted == true)
        {
            Debug.Log("Exited trigger");
            thing.GetComponent<scr_PipeInsertSpotControl>().Removal();
            inserted = false;
            GrabControl.gravOn = true;
        }
    }
}
