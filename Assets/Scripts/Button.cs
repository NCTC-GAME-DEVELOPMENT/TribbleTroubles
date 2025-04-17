using UnityEngine;

public class Button : InteractableObject
{
    public string buttonName;
    public GameObject activator;
    public bool Activated = true;
    private void OnEnable()
    {
        if (Activated)
        {

        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
