using System.Collections.Generic;
using UnityEngine;

public class Button : LensObject
{
    public string gameFlagName = "DefaultButton";
    public bool Activated = false;

    public List<LensObject> SameLensObjects;
    public Transform AnimateButton;
    
    private void OnEnable()
    {
        SetStatus();
    }

    public override void SetStatus()
    {
        Activated = GameManager.Instance.GetFlag(gameFlagName);
    }

     private void OnTriggerEnter(Collider other)
    {
        PlayerManager player = other.GetComponentInParent<PlayerManager>();
        HeavyObject bigThing = other.GetComponentInParent<HeavyObject>();

        if (bigThing || player )
        {
            OnEnter(); 
        }

    }

    private void OnTriggerExit(Collider other)
    {
        PlayerManager player = other.GetComponentInParent<PlayerManager>();
        HeavyObject bigThing = other.GetComponentInParent<HeavyObject>();

        if (bigThing || player)
        {
            OnExit();
        }
    }

    public virtual void OnEnter()
    {
        Debug.Log("Button Activated");
        Activated = true;
        GameManager.Instance.SetFlag(gameFlagName, Activated);
        foreach (LensObject obj in SameLensObjects)
        {
            obj.UpdateStatus();
        }

        // Other code here for animation purposes. 
        Vector3 newPosition = AnimateButton.position;
        newPosition.y -= 1;
        AnimateButton.position = newPosition;
    }

    public virtual void OnExit()
    {
        Debug.Log("Button Deactivated");
        Activated = false;
        GameManager.Instance.SetFlag(gameFlagName, Activated);
        foreach (LensObject obj in SameLensObjects)
        {
            obj.UpdateStatus();
        }

        // Other code here for animation purposes. 
        Vector3 newPosition = AnimateButton.position;
        newPosition.y += 1;
        AnimateButton.position = newPosition;
    }
}
