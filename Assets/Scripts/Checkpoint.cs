using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject model;
    public bool FlagIsRaised = false;

    public Animation anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (FlagIsRaised) 
        {
            // Has set this checkpoint already
            return; 
        }

        PlayerManager player = other.gameObject.GetComponentInParent<PlayerManager>();
        if (player != null) 
        {
            FlagIsRaised = true;
            GameManager.Instance.SetCheckPoint(gameObject);
            RaiseTheFlag();
        }

    }
    public void RaiseTheFlag() 
        {
        if (anim != null) {
            anim.Play("FlagRaiseAnimation");
        }
        else 
        {
            Debug.LogWarning("Animation component is not assigned!");
        }
    }

}
