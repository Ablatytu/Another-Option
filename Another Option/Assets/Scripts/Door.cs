using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform door;
    public bool IsOpen;
    public float spped;
    public Vector3 startPos, endPos;

    private void Start()
    {
        startPos = transform.position;
    }
    private void Update()
    {
        if (IsOpen)
            door.position = Vector3.MoveTowards(door.position, endPos, spped * Time.deltaTime);
        else
            door.position = Vector3.MoveTowards(door.position, startPos, spped * Time.deltaTime);
    }
}
