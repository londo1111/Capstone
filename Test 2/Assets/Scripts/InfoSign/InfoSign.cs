using UnityEngine;
using TMPro;

public class InfoSign : MonoBehaviour
{
    [SerializeField]
    private string textToDisplay;

    private GameObject signDisplay;
    private TextMeshProUGUI signText;

    private void Awake()
    {
        signDisplay = transform.GetChild(0).gameObject;
        signText = signDisplay.transform.GetChild(1).GetComponent<TextMeshProUGUI>();

        signDisplay.SetActive(false);
        signText.text = textToDisplay;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            signDisplay.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            signDisplay.SetActive(false);
        }
    }
}
