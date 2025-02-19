using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class SwitchPlayer : MonoBehaviour
{
    public FirstPersonMovement[] movements;
    public FirstPersonLook[] looks;
    public Camera[] cameras;
    private bool IsSwitched = false;
    public Transform switchedPL;
    public Transform currectPL;
    public Transform pointRaySwitched;
    public Transform pointRayCurrect;
    public Animator currectPLAnim;
    public Animator switchedPLAnim;

    private void Start()
    {
        Switch();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            Switch();
        }
        switchedPL.position = new Vector3(currectPL.position.x, currectPL.position.y, -currectPL.position.z);
        switchedPLAnim.SetInteger("Run", currectPLAnim.GetInteger("Run"));
        switchedPLAnim.SetBool("Idle", currectPLAnim.GetBool("Idle"));
    }
    public void Switch()
    {
        if (IsSwitched)
        {
            IsSwitched = false;
            switchedPL = movements[0].transform;
            currectPL = movements[1].transform;
            movements[0].Switched = true;
            movements[0].GetComponent<Collider>().isTrigger = true;
            movements[0].GetComponent<Rigidbody>().isKinematic = true;
            movements[0].enabled = false;
            cameras[1].enabled = true;
            movements[1].gameObject.SetActive(false);
            movements[1].Switched = false;
            movements[1].enabled = true;
            movements[1].GetComponent<Collider>().isTrigger = false;
            movements[1].GetComponent<Rigidbody>().isKinematic = false;
            movements[1].gameObject.SetActive(true);
            cameras[0].enabled = false;
            currectPLAnim = movements[1].animator;
            switchedPLAnim = movements[0].animator;
        }
        else
        {
            IsSwitched = true;
            switchedPL = movements[1].transform;
            currectPL = movements[0].transform;
            movements[0].gameObject.SetActive(false);
            movements[0].Switched = false;
            movements[0].GetComponent<Collider>().isTrigger = false;
            movements[0].GetComponent<Rigidbody>().isKinematic = false;
            movements[0].enabled = true;
            movements[0].gameObject.SetActive(true);
            cameras[1].enabled = false;
            movements[1].Switched = true;
            movements[1].GetComponent<Collider>().isTrigger = true;
            movements[1].GetComponent<Rigidbody>().isKinematic = true;
            movements[1].enabled = false;
            cameras[0].enabled = true;
            currectPLAnim = movements[0].animator;
            switchedPLAnim = movements[1].animator;
        }
    }
}
