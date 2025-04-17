using UnityEngine;

public class Door : InteractableObject
{
    public string doorName;
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
