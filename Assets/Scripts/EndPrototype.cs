using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPrototype : MonoBehaviour
{
    string EndGame = "EndScreen";

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Game Complete");
        SceneManager.LoadScene(EndGame);

        //Look, there are better ways to go to the next level, BUT WE HAVE NO TIME!!!
    }
}
