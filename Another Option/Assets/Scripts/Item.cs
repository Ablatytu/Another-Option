using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private Camera plCam;
    private Transform Holder;
    private Rigidbody _rigidbody;
    private Collider col;
    private bool IsPickUped;
    public LayerMask mask;

    private void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
        col = gameObject.GetComponent<Collider>();
    }
    private void Update()
    {
        if(IsPickUped && Input.GetKeyDown(KeyCode.Q))
        {
            Drop();
        }
        if(IsPickUped)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Holder.rotation, 3 * Time.deltaTime);
            if (Physics.Raycast(plCam.transform.position, plCam.transform.forward, out RaycastHit hit,  3.5f, mask))
            {
                Debug.Log("dwa");
                transform.position = Vector3.Lerp(transform.position, hit.point - plCam.transform.forward, 3 * Time.deltaTime);
            }
            else
                transform.position = Vector3.Lerp(transform.position, Holder.position, 3 * Time.deltaTime);
        }
    }
    public void PickUp()
    {
        if(!IsPickUped)
        {
            plCam = Camera.main;
            Holder = plCam.GetComponentInChildren<Holder>().transform;
            _rigidbody.isKinematic = true;
            col.isTrigger = true;
            IsPickUped = true;
        }
    }
    public void Drop()
    {
        _rigidbody.isKinematic = false;
        col.isTrigger = false;
        IsPickUped = false;
        transform.SetParent(null);
    }
}
