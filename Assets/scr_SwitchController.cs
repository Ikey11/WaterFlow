using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_SwitchController : MonoBehaviour
{
    [SerializeField] DoorBehavior _db;

    public bool switchActive = false;

    [Tooltip("Time Taken before switch takes effect")]
    public float _switchDelay = 0.2f;

    public void ToggleSwitch()
    {
        switchActive = !switchActive;

        new WaitForSeconds(_switchDelay);
        _db._isDoorOpen = switchActive;
    }
}
