using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    string MMScene = "MainMenu";
    string CreditsScene = "Credits";

    public void MenuScene()
    {
        Debug.Log("Credits");
        SceneManager.LoadScene(MMScene);
    }

    public void RollCredits()
    {
        Debug.Log("Credits");
        SceneManager.LoadScene(CreditsScene);
    }
}
