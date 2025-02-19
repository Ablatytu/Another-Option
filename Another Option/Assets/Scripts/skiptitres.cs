using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class skiptitres : MonoBehaviour
{
    public Image image;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !image.gameObject.activeSelf)
            StartCoroutine(Final());
    }
    private IEnumerator Final()
    {
        image.color = new Color32((byte)image.color.r, (byte)image.color.g, (byte)image.color.b, 0);
        image.gameObject.SetActive(true);
        byte a = 0;
        while (a < 255)
        {
            a += 5;
            image.color = new Color32((byte)image.color.r, (byte)image.color.g, (byte)image.color.b, a);
            yield return new WaitForSeconds(0.1f);
        }
        SceneManager.LoadScene(0);
    }
}
