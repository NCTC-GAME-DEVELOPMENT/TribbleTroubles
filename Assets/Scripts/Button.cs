using System.Collections.Generic;
using UnityEngine;

public class Button : LensObject
{
    public string gameFlagName = "DefaultButton";
    public bool Activated = false;

    public List<LensObject> SameLensObjects;
    public Transform AnimateButton;

    public int triggerCount = 0;
    
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
            triggerCount++;
            OnEnter(); 
        }

    }

    private void OnTriggerExit(Collider other)
    {
        PlayerManager player = other.GetComponentInParent<PlayerManager>();
        HeavyObject bigThing = other.GetComponentInParent<HeavyObject>();

        if (bigThing || player)
        {
            triggerCount--;
            if (triggerCount == 0)
            {
                OnExit();
            }
        }
    }

    public virtual void OnEnter()
    {
        Activated = true;
        GameManager.Instance.SetFlag(gameFlagName, Activated);
        foreach (LensObject obj in SameLensObjects)
        {
            obj.UpdateStatus();
        }

        // Other code here for animation purposes. 
        Vector3 newPosition = AnimateButton.position;
        newPosition.y = -1;
        AnimateButton.position = newPosition;
    }

    public virtual void OnExit()
    {
        Activated = false;
        GameManager.Instance.SetFlag(gameFlagName, Activated);
        foreach (LensObject obj in SameLensObjects)
        {
            obj.UpdateStatus();
        }

        // Other code here for animation purposes. 
        Vector3 newPosition = AnimateButton.position;
        newPosition.y = 1;
        AnimateButton.position = newPosition;
    }
}
