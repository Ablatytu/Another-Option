using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class finalPanelSpawn : MonoBehaviour
{
    public GameObject final;
    public Image finalimage;
    private bool IsFinal;
    public GameObject error;
    public void StartFinal()
    {
        final.SetActive(true);
        IsFinal = true;
    }
    private void Update()
    {
        if(IsFinal)
        {
            if(!final.activeSelf)
            {
                StartCoroutine(Final());
                IsFinal = false;
            }
        }
    }
    private IEnumerator Final()
    {
        error.SetActive(false);
        finalimage.color = new Color32((byte)finalimage.color.r, (byte)finalimage.color.g, (byte)finalimage.color.b, 0);
        finalimage.gameObject.SetActive(true);
        byte a = 0;
        while (a < 255)
        {
            a += 5;
            finalimage.color = new Color32((byte)finalimage.color.r, (byte)finalimage.color.g, (byte)finalimage.color.b, a);
            yield return new WaitForSeconds(0.1f);
        }
        SceneManager.LoadScene(4);
    }
}
