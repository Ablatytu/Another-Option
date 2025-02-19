using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cutscene : MonoBehaviour
{
    public FirstPersonMovement[] movements;
    public GameObject[] UI;
    public GameObject Cuts;
    private bool IsStarted;
    public Transform point;
    public string Text;
    public TextMeshProUGUI uGUI;
    public AudioClip clip;
    public AudioSource source;
    public Cirena cirena;
    public float speed;
    public IEnumerator StartCuts(float st)
    {
        yield return new WaitForSeconds(st);
        IsStarted = true;
        for (int i = 0; i < UI.Length; i++)
            UI[i].SetActive(false);
        for (int i = 0; i < movements.Length; i++)
            if (movements[i].Switched == false)
            {
                movements[i].enabled = false;
                movements[i].enabled = false;
                movements[i].transform.position = point.transform.position;
                movements[i].transform.rotation = point.transform.rotation;
            }
        Cuts.SetActive(true);
        foreach (char c in Text.ToCharArray())
        {
            source.PlayOneShot(clip);
            uGUI.text += c;
            yield return new WaitForSeconds(speed);
        }
    }
    private void Update()
    {
        if(IsStarted)
        {
            if(Input.GetKeyDown(KeyCode.Q))
            {
                Cuts.SetActive(false);
                for (int i = 0; i < movements.Length; i++)
                    if (movements[i].Switched == false)
                        movements[i].enabled = true;
                cirena.Play();
                IsStarted = false;
            }
        }
    }
}
