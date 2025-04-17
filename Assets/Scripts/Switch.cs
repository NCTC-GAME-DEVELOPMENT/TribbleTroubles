using UnityEngine;

public class Switch : InteractableObject
{
    public string switchName;
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
