using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    [SerializeField]
    private Transform creditText;

    [SerializeField]
    private float scrollTime;

    private void Start()
    {
        StartCoroutine(RollCredits());
    }

    private IEnumerator RollCredits()
    {
        creditText.LeanMoveLocal(new Vector2(0f, 955f), scrollTime).callOnCompletes();

        yield return new WaitForSeconds(scrollTime);

        SceneManager.LoadScene(0);
    }
}
