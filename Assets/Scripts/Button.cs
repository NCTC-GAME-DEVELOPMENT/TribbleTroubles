using UnityEngine;

public class Button : InteractableObject
{
    public string gameFlagName = "DefaultButton";
    public bool Activated = true;
    private void OnEnable()
    {
        Activated = GameManager.Instance.GetFlag(gameFlagName);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Activated = true;
        GameManager.Instance.SetFlag(gameFlagName, Activated);
    }

    private void OnTriggerExit(Collider other)
    {
        Activated = false;
        GameManager.Instance.SetFlag(gameFlagName, Activated);
    }
}
