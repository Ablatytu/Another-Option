using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactive : MonoBehaviour
{
    Camera cam;
    public LayerMask mask;
    private FirstPersonMovement movement;
    private void Start()
    {
        cam = gameObject.GetComponent<Camera>();
        movement = gameObject.GetComponentInParent<FirstPersonMovement>();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && !movement.Switched)
        {
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hit, 1.5f, mask))
            {
                if (hit.transform.GetComponentInChildren<lever>())
                {
                    Debug.Log("dwa");
                    hit.transform.GetComponentInChildren<lever>().Open();
                    return;
                }
                if(hit.transform.GetComponentInChildren<Item>())
                {
                    hit.transform.GetComponentInChildren<Item>().PickUp();
                    return;
                }
                if (hit.transform.GetComponent<spawnPanel>())
                {
                    hit.transform.GetComponent<spawnPanel>().Interactive();
                    return;
                }
                if (hit.transform.GetComponent<finalPanelSpawn>())
                    hit.transform.GetComponent<finalPanelSpawn>().StartFinal();
            }
        }
    }
}
