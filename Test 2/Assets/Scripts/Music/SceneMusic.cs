using System.Collections;
using System.Collections.Generic;
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

        if (FindObjectsOfType<SceneMusic>().Length > 1) { Destroy(gameObject); }

        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        SceneManager.sceneLoaded += SceneLoaded;
    }

    private void SceneLoaded(Scene loadedScene, LoadSceneMode mode)
    {
        if (SceneManager.GetActiveScene().buildIndex != originalScene)
        {
            Destroy(gameObject);
        }
    }
}
