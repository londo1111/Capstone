using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class XPManager : MonoBehaviour
{
    [Header("XP Configs")]
    public static int playerLevel = 0;
    public int PlayerLevel { get { return playerLevel; } }

    public static float _currentXP = 0f;
    [SerializeField]
    private float _nextLevelXP = 100f;

    // Declaring variables that manage XP

    [Header("UI elements")]

    [SerializeField]
    private TextMeshProUGUI _levelDisplay;
    [SerializeField]
    private Image _fillPart;

    // Declaring variables for UI elements

    private void Awake()
    {
        _levelDisplay.text = "Level: " + playerLevel;
        _nextLevelXP = 100f * playerLevel;
    }

    private void Update()
    {
        UpdateXPBar(); // Calls UpdateXPBar method every frame
    }

    public void AddToXPAmount(float amountToAdd) // Declares public method that accepts a float value
    {
        _currentXP += amountToAdd; // Adds passed in value to current XP amount
        print(_currentXP);

        if (_currentXP >= _nextLevelXP) // If XP amount >= then next level requirement, level up
        {
            PlayerLevelUp(1); // Calls PlayerLevelUp method and passes in 1
        }
    }

    public void PlayerLevelUp(int levelAmount) // Declares method that accepts an int value
    {
        Debug.Log("Level up!");

        playerLevel += levelAmount; // Adds passed in value to player's current level
        _levelDisplay.text = "Level: " + playerLevel; // Changes display text to player's new level

        _currentXP -= _nextLevelXP; // Ensures XP earned before leveling up is saved for next level
        _nextLevelXP = 100f * playerLevel; // Simple algorithm for determining next level XP needed amount
    }

    private void UpdateXPBar()
    {
        float fillAmount = _currentXP / _nextLevelXP; // Divides current XP by the next level XP amount
        _fillPart.fillAmount = fillAmount; // Sets fillAmount of the bar sprite to the fillAmount variable
    }

    public void SkillPurchased(int levelsToRemove)
    {
        playerLevel -= levelsToRemove;
        _levelDisplay.text = "Level: " + playerLevel;
        _nextLevelXP = 100f * playerLevel;

        if (_currentXP >= _nextLevelXP)
        {
            PlayerLevelUp(1);
        }
    }
}
