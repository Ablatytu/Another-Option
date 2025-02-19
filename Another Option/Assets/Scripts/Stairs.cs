using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Stairs : MonoBehaviour
{
    public GameObject exit;
    public bool IsExit;
    private int count;

    private void OnEnable()
    {
        if (IsExit)
            StartCoroutine(Enable());
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<FirstPersonMovement>() && !IsExit)
        {
            FirstPersonMovement movement = other.GetComponent<FirstPersonMovement>();
            movement.GetComponent<Jump>().enabled = false;
            movement.Landing = true;
            exit.SetActive(true);
        }
        else
        {
            if(other.GetComponent<FirstPersonMovement>())
            {
                count++;
                if (count >= 2)
                {
                    FirstPersonMovement movement = other.GetComponent<FirstPersonMovement>();
                    movement.GetComponent<Jump>().enabled = true;
                    movement.Landing = false;
                    count = 0;
                    exit.SetActive(false);
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<FirstPersonMovement>() && !IsExit)
        {
            FirstPersonMovement movement = other.GetComponent<FirstPersonMovement>();
            movement.GetComponent<Jump>().enabled = true;
            movement.Landing = false;
            count = 0;
            exit.SetActive(false);
        }
    }

    private IEnumerator Enable()
    {
        yield return new WaitForSeconds(1);
        count = 2;
    }
}
