using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenMenu : MonoBehaviour
{
    public void OpenStartMenu()
    {
        SceneManager.LoadScene(0);
    }
}
