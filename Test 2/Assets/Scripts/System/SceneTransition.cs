using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string sceneToLoad;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            Destroy(FindObjectOfType<SceneMusic>().gameObject);

            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
