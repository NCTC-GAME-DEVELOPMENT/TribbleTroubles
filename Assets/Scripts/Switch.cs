using UnityEngine;

public class Switch : InteractableObject
{
    public string gameFlagName = "DefaultSwitch";
    public bool Activated = false;
    private void OnEnable()
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
        
    }
}
