using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Vector3 TeleporterOut;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        PlayerManager player = other.GetComponentInParent<PlayerManager>();
        if(player != null)
        {
            player.transform.position = TeleporterOut;
        }
    }
}
