using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class SceneMusic : MonoBehaviour
{
    private AudioSource audioSrc;

    private int originalScene;

    private void Awake()
    {
        audioSrc = GetComponent<AudioSource>();
        originalScene = SceneManager.GetActiveScene().buildIndex;
        audioSrc.Play();

        if (FindObjectsOfType<SceneMusic>().Length > 1)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex != originalScene)
        {
            Destroy(gameObject);
        }

        // SceneManager.sceneLoaded += SceneLoaded;
    }

    /*
    private void SceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log(scene.buildIndex);
        if (scene.buildIndex != originalScene || FindObjectsOfType<SceneMusic>().Length > 1)
        {
            Destroy(gameObject);
        }
    }
    */
}
