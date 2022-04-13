using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void StartFirstLevel()
    {
        SkillTreeManager.ResetSkills();
        XPManager.ResetStats();
        SceneManager.LoadScene(1);
    }
}
