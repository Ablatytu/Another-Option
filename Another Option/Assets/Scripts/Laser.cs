using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public LayerMask mask;
    public float Leght;
    public int numberReact;

    private LineRenderer line;
    private Vector3 direct;
    public GameObject Trigger;
    private bool CanRefclect = true;
    private void Start()
    {
        line = gameObject.GetComponent<LineRenderer>();
    }

    private void Update()
    {
        Reflect();
    }

    private void Reflect()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        line.positionCount = 1;
        line.SetPosition(0, transform.position);

        float remainLeght = Leght;

        for (int i = 0; i < numberReact; i++)
        {
            if (Physics.Raycast(ray.origin, ray.direction, out RaycastHit hit, remainLeght, mask))
            {
                line.positionCount += 1;
                line.SetPosition(line.positionCount - 1, hit.point);
                Trigger.transform.position = hit.point;
                if (hit.collider.GetComponent<ButtonLaser>())
                    return;
                remainLeght -= Vector3.Distance(ray.origin, hit.point);

                ray = new Ray(hit.point, Vector3.Reflect(ray.direction, hit.normal));
                    
            }
            else
            {
                line.positionCount += 1;
                line.SetPosition(line.positionCount - 1, ray.origin + (transform.forward * remainLeght));
            }
        }

    }
}
