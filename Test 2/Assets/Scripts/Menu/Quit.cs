using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour
{
    public void QuitGame()
    {
            Application.Quit();     
    }

void Update()
{
    if (Input.GetKey("escape"))
    {
        Application.Quit();
    }
}

    public void Back()
    {
        SceneManager.LoadScene(0);
    }

    public void CredtiSOIFJ()
    {
        SceneManager.LoadScene(10);
    }
}
