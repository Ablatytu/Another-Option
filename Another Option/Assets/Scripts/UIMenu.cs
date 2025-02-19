using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenu : MonoBehaviour
{
    public GameObject HowPlay;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
    public void Play()
    {
        SceneManager.LoadScene(2);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void How()
    {
        if (HowPlay.activeSelf)
        {
            HowPlay.SetActive(false);
        }
        else
        {
            HowPlay.SetActive(true);
        }
    }
}
