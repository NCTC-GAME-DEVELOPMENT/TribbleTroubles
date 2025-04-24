using UnityEngine;

public class InteractableObject : LensObject
{
    public virtual void PerformInteraction()
    {

    }

    public virtual void OnEnter()
    {

    }

    public virtual void OnExit()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerManager player = other.GetComponentInParent<PlayerManager>();
        if (player)
        {
            player.currentObject = this; 
            OnEnter();
        }

    }

    private void OnTriggerExit(Collider other)
    {
        PlayerManager player = other.GetComponentInParent<PlayerManager>();
        if (player)
        {
            player.currentObject = null;
            OnExit(); 
        }
    }
}
