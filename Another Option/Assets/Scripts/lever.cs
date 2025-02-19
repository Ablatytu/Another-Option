using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lever : MonoBehaviour
{
    public Transform mech;
    public float speed;
    public Door door;
    public Cutscene GetCutscene;
    public Conveer conveer;
    public bool isOpen;
    public Quaternion endRotation;
    private Quaternion startRot;
    private Vector3 startPos;
    public Vector3 endPos;
    public enum Type
    {
        Lever,
        button
    }
    public Type ButtonType;

    private void Start()
    {
        startRot = mech.rotation;
        startPos = transform.localPosition;
    }

    private void Update()
    {
        switch(ButtonType)
        {
            case Type.Lever:
                if (isOpen)
                {
                    mech.rotation = Quaternion.Lerp(mech.rotation, endRotation, speed * Time.deltaTime);
                }
                else
                {
                    mech.rotation = Quaternion.Lerp(mech.rotation, startRot, speed * Time.deltaTime);
                }
                break;
            case Type.button:
                if (isOpen)
                {
                    mech.localPosition = Vector3.Lerp(mech.localPosition, endPos, speed * Time.deltaTime);
                }
                else
                {
                    mech.localPosition = Vector3.Lerp(mech.localPosition, startPos, speed * Time.deltaTime);
                }
                break;
        }
    }
    public void Open()
    {
        if(isOpen)
        {
            isOpen = false;
            if(door)
                door.IsOpen = false;
            else
                conveer.IsWork = false;
            if (GetCutscene)
            {
                GetCutscene.StartCoroutine(GetCutscene.StartCuts(7f));
                GetCutscene = null;
            }
        }
        else
        {
            isOpen = true;
            if (door)
                door.IsOpen = true;
            else
                conveer.IsWork = true;
            if (GetCutscene)
            {
                GetCutscene.StartCoroutine(GetCutscene.StartCuts(7f));
                GetCutscene = null;
            }
        }
    }
}
