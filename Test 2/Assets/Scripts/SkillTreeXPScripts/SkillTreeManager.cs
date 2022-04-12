using UnityEngine;
using UnityEngine.UI;

public class SkillTreeManager : MonoBehaviour
{
    /* SkillTreeManager script
     * Manages the player's skills and skill tree
     * Refrain from touching anything unless you know what you're doing
     * By Benjamin Neuenschwander
     */

    private PlayerMovement plrMovement;
    private XPManager xpManager;

    [SerializeField]
    private Color _purchasedColor;

    [Header("Game Objects")]

    [SerializeField]
    private GameObject _parentCanvas;

    private GameObject _skillTreeCanvas;
    private GameObject _skillTreeButton;

    private GameObject _buttons;

    private GameObject _damageI;
    private GameObject _damageII;
    private GameObject _damageIII;

    private GameObject _speedI;
    private GameObject _speedII;
    private GameObject _speedIII;

    private static bool[] purchases = new bool[5];

    // private PlayerScript _playerScript;


    // ^^^ Variable declaration ^^^

    /* Skill tree stats
     * 
     * Damage I = 35 (costs 1 level)
     * Damage II = 45 (costs 3 levels)
     * Damage II = 60 (costs 5 levels)
     * 
     * Speed I = 3 (costs 1 level)
     * Speed II = 4 (costs 3 levels)
     * Speed II = 5 (costs 5 levels)
     * 
     * Health I = 130 (costs 1 level)
     * Health II = 160 (costs 3 levels)
     * Health III = 200 (costs 5 levels)
     * 
     */
    
    private void Awake()
    {
        xpManager = FindObjectOfType<XPManager>();
        plrMovement = FindObjectOfType<PlayerMovement>();
        // _playerScript = FindObjectOfType<PlayerScript>();

        _skillTreeCanvas = _parentCanvas.transform.Find("SkillTree").gameObject;
        _skillTreeButton = _parentCanvas.transform.Find("OpenTree").gameObject;
        _buttons = _skillTreeCanvas.transform.Find("Buttons").gameObject;

        _damageI = _buttons.transform.Find("Damage1").gameObject;
        _damageII = _buttons.transform.Find("Damage2").gameObject;
        _damageIII = _buttons.transform.Find("Damage3").gameObject;

        _speedI = _buttons.transform.Find("Speed1").gameObject;
        _speedII = _buttons.transform.Find("Speed2").gameObject;
        _speedIII = _buttons.transform.Find("Speed3").gameObject;

        // ^^^ Assigns gameobjects to variables previously declared ^^^

        CheckPurchases();
    }

    
    public void ButtonClick(string name) // Declares "ButtonClick" method that accepts a string as a parameter, only the buttons in the canvas use this
    {
        int plrLevel = xpManager.PlayerLevel;

        switch (name) // Declares switch statement that inserts the 'name' variable
        {
            // UI cases

            case "Open": // If name == "Open", hides skillTreeButton and opens skillTreeCanvas
                _skillTreeCanvas.SetActive(true);
                _skillTreeButton.SetActive(false);
                break;

            case "Close": // If name == "Close", opens skillTreeButton and hides skillTreeCanvas
                _skillTreeCanvas.SetActive(false);
                _skillTreeButton.SetActive(true);
                break;


            // Purchasing skills cases

            // Damage upgrades

            case "Damage1": // If name == "Damage1" and playerLevel is greater than or equal to 2, purchases damage I upgrade
                if (plrLevel >= 2)
                {
                    xpManager.SkillPurchased(1); // Removes the amount of levels via the value passed in
                    _damageI.GetComponent<Button>().interactable = false;
                    _damageI.GetComponent<Image>().color = _purchasedColor;
                    _damageII.GetComponent<Button>().interactable = true;
                    // _playerScript.weaponDamage = 35f;
                    purchases[0] = true;
                }
                break;

            case "Damage2":
                if (plrLevel >= 4)
                {
                    xpManager.SkillPurchased(3); // Removes the amount of levels via the value passed in
                    _damageII.GetComponent<Button>().interactable = false;
                    _damageII.GetComponent<Image>().color = _purchasedColor;
                    _damageIII.GetComponent<Button>().interactable = true;
                    // _playerScript.weaponDamage = 45f;
                    purchases[1] = true;
                }
                break;

            case "Damage3":
                if (plrLevel >= 6)
                {
                    xpManager.SkillPurchased(5); // Removes the amount of levels via the value passed in
                    _damageIII.GetComponent<Button>().interactable = false;
                    _damageIII.GetComponent<Image>().color = _purchasedColor;
                    // _playerScript.weaponDamage = 60f;
                    purchases[2] = true;
                }
                break;

            // Speed upgrades

            case "Speed1":
                if (plrLevel >= 2) // If name == "Speed1" and playerLevel is greater than or equal to 2, purchase speed I upgrade
                {
                    xpManager.SkillPurchased(1); // Removes the amount of levels via the value passed in
                    _speedI.GetComponent<Button>().interactable = false;
                    _speedI.GetComponent<Image>().color = _purchasedColor;
                    _speedII.GetComponent<Button>().interactable = true;
                    plrMovement.moveSpeed = 6f;
                    purchases[3] = true;
                }
                break;

            case "Speed2":
                if (plrLevel >= 4) // If name == "Speed2" and playerLevel is greater than or equal to 4, purchase speed II upgrade
                {
                    xpManager.SkillPurchased(3); // Removes the amount of levels via the value passed in
                    _speedII.GetComponent<Button>().interactable = false;
                    _speedII.GetComponent<Image>().color = _purchasedColor;
                    _speedIII.GetComponent<Button>().interactable = true;
                    plrMovement.moveSpeed = 7f;
                    purchases[4] = true;
                }
                break;

            case "Speed3":
                if (plrLevel >= 6) // If name == "Speed3" and playerLevel is greater than or equal to 6, purchase speed III upgrade
                {
                    xpManager.SkillPurchased(5); // Removes the amount of levels via the value passed in
                    _speedIII.GetComponent<Button>().interactable = false;
                    _speedIII.GetComponent<Image>().color = _purchasedColor;
                    plrMovement.moveSpeed = 8f;
                    purchases[5] = true;
                }
                break;
        }
    }

    private void CheckPurchases()
    {
        for (int i = 0; i < purchases.Length; i++)
        {
            if (purchases[i])
            {
                switch (i)
                {
                    case 0:
                        _damageI.GetComponent<Button>().interactable = false;
                        _damageI.GetComponent<Image>().color = _purchasedColor;
                        _damageII.GetComponent<Button>().interactable = true;
                        // _playerScript.weaponDamage = 35f;
                        break;

                    case 1:
                        _damageII.GetComponent<Button>().interactable = false;
                        _damageII.GetComponent<Image>().color = _purchasedColor;
                        _damageIII.GetComponent<Button>().interactable = true;
                        // _playerScript.weaponDamage = 45f;
                        break;

                    case 2:
                        _damageIII.GetComponent<Button>().interactable = false;
                        _damageIII.GetComponent<Image>().color = _purchasedColor;
                        // _playerScript.weaponDamage = 60f;
                        break;

                    case 3:
                        _speedI.GetComponent<Button>().interactable = false;
                        _speedI.GetComponent<Image>().color = _purchasedColor;
                        _speedII.GetComponent<Button>().interactable = true;
                        plrMovement.moveSpeed = 6f;
                        break;

                    case 4:
                        _speedII.GetComponent<Button>().interactable = false;
                        _speedII.GetComponent<Image>().color = _purchasedColor;
                        _speedIII.GetComponent<Button>().interactable = true;
                        plrMovement.moveSpeed = 7f;
                        break;

                    case 5:
                        _speedIII.GetComponent<Button>().interactable = false;
                        _speedIII.GetComponent<Image>().color = _purchasedColor;
                        plrMovement.moveSpeed = 8f;
                        break;
                }
            }
        }
    }
}
