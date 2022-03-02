using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MoneyManager : MonoBehaviour
{
    private TextMeshProUGUI moneyText;

    [SerializeField]
    private int currentCoins = 0;
    public int CurrentCoins { get { return currentCoins; } }
    
    private void Start()
    {
        if (FindObjectsOfType<MoneyManager>().Length > 1)
        {
            Destroy(gameObject);
        }

        moneyText = GameObject.FindGameObjectWithTag("GoldDisplay").GetComponent<TextMeshProUGUI>();
        moneyText.text = ": " + currentCoins.ToString();

        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Loaded scene " + scene.name);

        if (scene.buildIndex == 0)
        {
            Destroy(gameObject);
        }

        moneyText = GameObject.FindGameObjectWithTag("GoldDisplay").GetComponent<TextMeshProUGUI>();
        moneyText.text = ": " + currentCoins.ToString();
    }

    public void AddCoins(int coinToAdd)
    {
        if (moneyText == null)
        {
            moneyText = GameObject.FindGameObjectWithTag("GoldDisplay").GetComponent<TextMeshProUGUI>();
        }

        currentCoins += Mathf.Abs(coinToAdd);
        moneyText.text = ": " + currentCoins;
    }

    public void RemoveCoins(int coinsToRemove)
    {
        if (moneyText == null)
        {
            moneyText = GameObject.FindGameObjectWithTag("GoldDisplay").GetComponent<TextMeshProUGUI>();
        }

        currentCoins -= Mathf.Abs(coinsToRemove);
        moneyText.text = ": " + currentCoins;
    }
}