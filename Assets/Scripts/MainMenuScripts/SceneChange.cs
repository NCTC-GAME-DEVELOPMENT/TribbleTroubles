using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneChange : MonoBehaviour
{
    string MMScene = "MainMenu";
    string CreditsScene = "Credits";
    string BeginGame = "Tutorial1(Sewell)";

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

    public void StartGame()
    {
        Debug.Log("Level 1");
        SceneManager.LoadScene(BeginGame);
    }

    public void QuitApplication()
    {
        Application.Quit();

  
    }
}
