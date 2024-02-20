using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room001Manager : MonoBehaviour
{
    public scr_PipeInsertSpotControl PipePuzzle1;
    public DoorBehavior Door;

    // Update is called once per frame
    void Update()
    {
        // When pipepuzzle working, door is open
        Door._isDoorOpen = PipePuzzle1.working;
    }
}
