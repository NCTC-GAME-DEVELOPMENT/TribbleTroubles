using UnityEngine;

public class Door : MonoBehaviour
{
    public string gameFlagName = "DefaultSwitch";
    public bool Activated = false;
    public GameObject ModelON;
    public GameObject ModelOFF;
    private void OnEnable()
    {
        Debug.Log("OnEnable " + gameFlagName);

        Activated = GameManager.Instance.GetFlag(gameFlagName);

        // set to it's activated position
        ModelON.SetActive(!Activated); 
        ModelOFF.SetActive(Activated);

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
