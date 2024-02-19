using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_SwitchController : MonoBehaviour
{
    [SerializeField] DoorBehavior _db;

    Animator _animator;

    public bool _switchActive = false;

    [Tooltip("Time Taken before switch takes effect")]
    public float _switchDelay = 0.2f;

    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
    }

    public void ToggleSwitch()
    {
        Debug.Log("scr_SwitchController: Switch at " + transform.position + " toggling to: " + !_switchActive);
        _switchActive = !_switchActive;

        // Play animation   
        _animator.SetBool("Toggled", _switchActive);
        
        StartCoroutine(OpenDoor(_switchDelay));
    }

    IEnumerator OpenDoor(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        _db._isDoorOpen = _switchActive;
    }   
}
