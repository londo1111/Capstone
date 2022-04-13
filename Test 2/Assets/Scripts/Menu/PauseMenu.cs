using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private SceneMusic music;

    private GameObject mainCanvas;
    private GameObject container;

    private void Awake()
    {
        music = FindObjectOfType<SceneMusic>();

        mainCanvas = GameObject.Find("Canvas");
        container = transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            mainCanvas.SetActive(false);
            container.SetActive(true);
            music.GetComponent<AudioSource>().Pause();
            Time.timeScale = 0;
        }
    }

    public void Resume()
    {
        mainCanvas.SetActive(true);
        container.SetActive(false);
        music.GetComponent<AudioSource>().Play();
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Time.timeScale = 1;
        Destroy(music.gameObject);
        SceneManager.LoadScene(0);
    }
}
