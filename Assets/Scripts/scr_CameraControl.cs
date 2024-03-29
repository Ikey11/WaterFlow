using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_CameraControl : MonoBehaviour
{
    public Transform cameraBody;
    public Transform playerBody;
    float cameraRotX = 0f;
    float cameraRotY = 0f;
    public float sensitivity = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cameraRotY += Input.GetAxis("Mouse X") * sensitivity;
        cameraRotX -= Input.GetAxis("Mouse Y") * sensitivity;
        cameraRotX = Mathf.Max(-90, Mathf.Min(90, cameraRotX));
        //cameraBody.rotation = new Quaternion(cameraRotX, cameraRotY, 0, cameraBody.rotation.w);
        playerBody.localEulerAngles = new Vector3(0, cameraRotY, 0);
        transform.localEulerAngles = new Vector3(cameraRotX, 0, 0);
    }
}
