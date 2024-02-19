using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_InsertableController : MonoBehaviour
{
    public Rigidbody rbSelf;
    public scr_GrabbableController GrabControl;
    public bool inserted = false;
    Vector3 insertionLocation;

    // Start is called before the first frame update
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
            Debug.Log("Begin lock!");
            inserted = true;
            GrabControl.grabbed = false;
            GrabControl.gravOn = false;
            transform.position = thing.transform.position;
            insertionLocation = thing.transform.position;
            transform.rotation = new Quaternion(0, 0, 0, 0);
            rbSelf.freezeRotation = true;
            rbSelf.AddForce(-rbSelf.GetAccumulatedForce());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exited trigger");
        inserted = false;
        GrabControl.gravOn = true;
    }
}
