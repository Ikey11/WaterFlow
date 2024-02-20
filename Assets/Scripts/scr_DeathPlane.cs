using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class scr_DeathPlane : MonoBehaviour
{
    public Vector3 spawnLocation;

    public void respawn(Transform thing)
    {
        thing.transform.position = spawnLocation;
    }
}
