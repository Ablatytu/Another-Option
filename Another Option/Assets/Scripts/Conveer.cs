using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveer : MonoBehaviour
{
    private Rigidbody rb;
    public bool IsWork;
    public float speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if(IsWork)
        {
            Vector3 pos = rb.position;
            rb.position += transform.forward * speed * Time.fixedDeltaTime;
            rb.MovePosition(pos);
        }
    }
}
