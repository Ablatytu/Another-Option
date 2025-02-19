using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class finalScript : MonoBehaviour
{
    public TMP_InputField TMP_Input;
    public Cirena cirena;
    public Light _light;
    private bool x1;
    private bool x2;

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
            Check();
    }
    private void Check()
    {
        if (!x1 && TMP_Input.text == "0.6")
        {
            TMP_Input.text = "Верно";
            x1 = true;
        }
        if(!x2 && TMP_Input.text == "-0.6")
        {
            TMP_Input.text = "Верно";
            x2 = true;
        }
        if(x2 && x1)
        {
            gameObject.SetActive(false);
            cirena.Stop();
            _light.color = new Color(1, 1, 1, 1);
        }
    }
}
