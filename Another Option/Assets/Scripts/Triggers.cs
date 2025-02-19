using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Triggers : MonoBehaviour
{
    public enum WhatTypeTrigger
    {
        let,
        exit
    }
    public WhatTypeTrigger TypeTrigger;
    public int scene;
    public Transform point;
    public Cirena cirena;
    public bool PlaySir;
    private int count;
    public GameObject[] levels;
    public bool IsPerexod;
    public Transform[] points;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<FirstPersonMovement>())
        {
            switch(TypeTrigger)
            {
                case WhatTypeTrigger.let:
                    if (!collision.gameObject.GetComponent<FirstPersonMovement>().Switched)
                    {
                        SceneManager.LoadScene(0);
                    }
                    break;
                case WhatTypeTrigger.exit:
                    if (!collision.gameObject.GetComponent<FirstPersonMovement>().Switched)
                    {
                        if (IsPerexod)
                        {
                            if (count >= levels.Length)
                            {
                                SceneManager.LoadScene(3);
                                return;
                            }
                            levels[count].SetActive(false);
                            count++;
                            if (count >= levels.Length)
                            {
                                SceneManager.LoadScene(3);
                                return;
                            }
                            levels[count].SetActive(true);
                            collision.transform.position = points[count].transform.position;
                            collision.transform.rotation = points[count].transform.rotation;
                        }
                        else
                        {
                            collision.transform.position = point.transform.position;
                            collision.transform.rotation = point.transform.rotation;
                        }
                        if(PlaySir)
                            cirena.Play();
                        else
                            cirena.Stop();
                    }
                    break;
            }
        }
    }
}
