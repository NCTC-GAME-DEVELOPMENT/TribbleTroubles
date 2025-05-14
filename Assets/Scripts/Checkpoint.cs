using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject model;
    public Transform FlagModel;
    public bool FlagIsRaised = false;
    public Vector3 FlagUp;
    public float speed = 5;

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
        FlagModel.transform.position = Vector3.Lerp(transform.position, FlagUp, Time.deltaTime * speed);
    }

}
