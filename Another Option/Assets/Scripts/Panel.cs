using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Panel : MonoBehaviour
{
    public float[] koef = new float[3];
    public float x1, x2;
    public bool Null;
    public bool D0;
    public TMP_InputField field;
    public TextMeshProUGUI YpaB;
    public bool x1Comp, x2Comp;
    public bool Complite;

    public void Generate()
    {
        x1Comp = false;
        x2Comp = false;
        Null = false;
        D0 = false;
        Complite = false;
        koef[0] = Random.Range(1, 5);
        for (int i = 1; i < koef.Length; i++)
            koef[i] = Random.Range(-10, 10);
        UpdateTXT();
        float D = (Mathf.Pow(koef[1], 2)) - (4 * koef[0] * koef[2]);
        switch(D)
        {
            case < 0:
                Null = true;
                break;
            case > 0:
                x1 = (-koef[1] - Mathf.Sqrt(D)) / (2 * koef[0]);
                x2 = (-koef[1] + Mathf.Sqrt(D)) / (2 * koef[0]);
                x1 = Mathf.RoundToInt(x1);
                x2 = Mathf.RoundToInt(x2);
                break;
            case 0:
                D0 = true;
                x1 = -koef[1] / (2 * koef[0]);
                x1 = Mathf.RoundToInt(x1);
                break;
        }
    }
    private void UpdateTXT()
    {
        YpaB.text = koef[0] + "x^2 + " + koef[1] + "x + " + koef[2] + " = 0"; 
    }
    private void OnEnable()
    {
        Generate();
        Cursor.lockState = CursorLockMode.Confined;
    }
    private void OnDisable()
    {
        Generate();
        Cursor.lockState = CursorLockMode.Locked;
        Null = false;
        D0 = false;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
            gameObject.SetActive(false);
        if (Input.GetKeyDown(KeyCode.Return))
            Check();
    }
    public void Check()
    {
        if(D0)
        {
            if(int.Parse(field.text) == x1)
            {
                field.text = "Верно".ToString();
                {
                    gameObject.SetActive(false);
                    Complite = true;
                }
            }
            else
            {
                field.text = "Неверно".ToString();
            }
        }
        if(Null)
        {
            if (field.text == "нк")
            {
                field.text = "Верно".ToString();
                {
                    gameObject.SetActive(false);
                    Complite = true;
                }
            }
            else
            {
                field.text = "Неверно".ToString();
            }
        }
        if(!Null && !D0)
        {
            if (int.Parse(field.text) == x1 && !x1Comp)
            {
                field.text = "Верно".ToString();
                x1Comp = true;
                return;
            }
            else
                if(!x1Comp)
                    field.text = "Неверно".ToString();
            if (int.Parse(field.text) == x2 && !x2Comp)
            {
                field.text = "Верно".ToString();
                x2Comp = true;
            }
            else
                if (!x2Comp)
                    field.text = "Неверно".ToString();
            if (x1Comp && x2Comp)
            {
                gameObject.SetActive(false);
                Complite = true;
            }
        }
    }
}
