using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Loading : MonoBehaviour
{
    public string txt;
    public AudioSource source;
    public AudioClip clip;
    public TextMeshProUGUI uGUI;
    public float speed;
    public Image image;
    public int scene;
    private bool Can = true;
    public bool perexod = true;
    public Cirena cirena;
    public FirstPersonMovement movement;
    public GameObject Final;
    private void Start()
    {
        StartCoroutine(StartScene());
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q) && Can)
        {
            Can = false;
            StartCoroutine(LoadScene());
        }
    }
    private IEnumerator StartScene()
    {
        foreach (char c in txt.ToCharArray())
        {
            source.PlayOneShot(clip);
            uGUI.text += c;
            yield return new WaitForSeconds(speed);
        }
    }
    private IEnumerator LoadScene()
    {
        byte a = 0;
        while(a < 255)
        {
            a += 15;
            image.color = new Color32((byte)image.color.r, (byte)image.color.g, (byte)image.color.b, a);
            yield return new WaitForSeconds(0.1f);
        }
        if (perexod)
            SceneManager.LoadScene(scene);
        else
        {
            gameObject.SetActive(false);
            image.gameObject.SetActive(false);
            if(cirena)
                cirena.Play();
            if(movement)
                movement.enabled = true;
            if (Final)
                Final.SetActive(true);
        }
    }
        
}
