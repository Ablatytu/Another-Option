using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform point;

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Rigidbody>())
        {
            Transform transform = other.GetComponent<Rigidbody>().transform;
            transform.position = point.position;
            transform.localRotation = point.localRotation;
        }
    }
}
