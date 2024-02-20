using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_PipeInsertSpotControl : MonoBehaviour
{
    public AudioSource audioSound;
    public Vector3 pipeRotation;
    public string requiredPipeType = "default";
    public bool filled = false;
    public bool working = false;

    public void UpdateInsertion(string pipeType)
    {
        if (pipeType == requiredPipeType)
        {
            filled = true;
            working = true;
        }
        else
        {
            filled = true;
            working = false;
        }
        audioSound.Play();
    }

    public void Removal() 
    {
        filled = false;
        working = false;
    }
}
