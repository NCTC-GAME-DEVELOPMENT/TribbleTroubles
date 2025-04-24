using System.Collections.Generic;
using UnityEngine;


public class Switch : InteractableObject
{
    public string gameFlagName = "DefaultSwitch";
    public bool Activated = false;

    public List<LensObject> SameLensObjects;

    private void OnEnable()
    {
        SetStatus(); 
    }

    public override void SetStatus()
    {
        Debug.Log("OnEnable " + gameFlagName);

        Activated = GameManager.Instance.GetFlag(gameFlagName);

        // set to it's activated position
        SetScale();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void PerformInteraction()
    {

        Activated = !Activated; 
        SetScale();
        GameManager.Instance.SetFlag(gameFlagName, Activated);  
        
        foreach (LensObject obj in SameLensObjects)
        {
            obj.UpdateStatus(); 
        }
    }

    public override void OnEnter()
    {

    }

    public override void OnExit()
    {

    }

    public void SetScale()
    {
        Vector3 newScale = Vector3.one;
        if (Activated)
        {
            newScale.x *= -1;
        }
        gameObject.transform.localScale = newScale;
        //Here add thing to other function
    }
}
