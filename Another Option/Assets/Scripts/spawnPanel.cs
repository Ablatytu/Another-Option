using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class spawnPanel : MonoBehaviour
{
    public GameObject panel;
    public bool Pesh;
    public bool CanPesh;
    public enum Type
    {
        spawnCube,
        fantom
    }
    public Type typeBonus;
    public BonusComponent bonusComponent = new BonusComponent();
    private Panel panelscr;

    public void Interactive()
    {
        panel.SetActive(true);
        panelscr = panel.GetComponent<Panel>();
        Pesh = true;
    }
    private void Update()
    {
        if(CanPesh)
            if (Pesh)
                if (panelscr.Complite)
                {
                    Complite();
                    CanPesh = false;
                    Pesh = false;
                }
    }
    private void Complite()
    {
        switch(typeBonus)
        {
            case Type.spawnCube:
                Instantiate(bonusComponent.spawnCube, bonusComponent.point.position, bonusComponent.point.rotation);
                break;
            case Type.fantom:
                Material[] materials = new Material[3];
                Material[] oldMaterials = bonusComponent.spawnCube.GetComponent<MeshRenderer>().materials;
                for (int i = 0; i < oldMaterials.Length; i++)
                {
                    materials[i] = oldMaterials[i];
                }
                materials[2] = bonusComponent.matrixShader;
                bonusComponent.spawnCube.GetComponent<Collider>().enabled = false;
                bonusComponent.spawnCube.GetComponent<MeshRenderer>().materials = materials;
                break;
        }
    }
    [System.Serializable]
    public class BonusComponent
    {
        public GameObject spawnCube;
        public Transform point;
        public Material matrixShader;
    }
}
