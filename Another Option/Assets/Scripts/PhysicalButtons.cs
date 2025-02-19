using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalButtons : MonoBehaviour
{
    public Transform Button;
    public Vector3 startPos, endPos;
    public float speed;
    public bool IsOpen;
    public Door door;
    public enum Type
    {
        door,
        fantom
    }
    public Type typebuttonbonus;
    public Material MatrixShader;
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Rigidbody>())
        {
            if(other.GetComponent<FirstPersonMovement>() && !other.GetComponent<FirstPersonMovement>().Switched)
            {
                switch(typebuttonbonus)
                {
                    case Type.door:
                        IsOpen = true;
                        door.IsOpen = true;
                        break;
                    case Type.fantom:
                        IsOpen = true;
                        Material[] materials = new Material[3];
                        Material[] oldMaterials = door.GetComponent<MeshRenderer>().materials;
                        for (int i = 0; i < oldMaterials.Length; i++)
                        {
                            materials[i] = oldMaterials[i];
                        }
                        materials[2] = MatrixShader;
                        door.GetComponent<Collider>().enabled = false;
                        door.GetComponent<MeshRenderer>().materials = materials;
                        break;
                }
            }
            else
            {
                if(!other.GetComponent<FirstPersonMovement>())
                {
                    switch (typebuttonbonus)
                    {
                        case Type.door:
                            IsOpen = true;
                            door.IsOpen = true;
                            break;
                        case Type.fantom:
                            IsOpen = true;
                            Material[] materials = new Material[3];
                            Material[] oldMaterials = door.GetComponent<MeshRenderer>().materials;
                            for (int i = 0; i < oldMaterials.Length; i++)
                            {
                                materials[i] = oldMaterials[i];
                            }
                            materials[2] = MatrixShader;
                            door.GetComponent<Collider>().enabled = false;
                            door.GetComponent<MeshRenderer>().materials = materials;
                            break;
                    }
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        switch (typebuttonbonus)
        {
            case Type.door:
                IsOpen = false;
                door.IsOpen = false;
                break;
            case Type.fantom:
                IsOpen = false;
                Material[] materials = new Material[2];
                Material[] oldMaterials = door.GetComponent<MeshRenderer>().materials;
                for (int i = 0; i < materials.Length; i++)
                {
                    materials[i] = oldMaterials[i];
                }
                door.GetComponent<Collider>().enabled = true;
                door.GetComponent<MeshRenderer>().materials = materials;
                break;
        }
    }
    private void Update()
    {
        if(IsOpen)
        {
            Button.localPosition = Vector3.Lerp(Button.localPosition, endPos, speed * Time.deltaTime);
        }
        else
        {
            Button.localPosition = Vector3.Lerp(Button.localPosition, startPos, speed * Time.deltaTime);
        }
    }
}
