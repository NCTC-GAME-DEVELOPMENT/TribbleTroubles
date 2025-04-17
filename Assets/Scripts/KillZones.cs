using UnityEngine;
using UnityEngine.Events; 

public class KillZones : MonoBehaviour
{
    UnityEvent OnDeath; 

    private void OnTriggerEnter(Collider other)
    {
        
        PlayerManager player = other.gameObject.GetComponentInParent<PlayerManager>();
        if (player != null)
        {
            player.OnPlayerDeath();
            OnDeath?.Invoke(); 
        }

    }

}
