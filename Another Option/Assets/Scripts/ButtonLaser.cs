using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLaser : MonoBehaviour
{
    public Door door;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<LasetTrig>())
            door.IsOpen = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<LasetTrig>())
            door.IsOpen = false;
    }
}
