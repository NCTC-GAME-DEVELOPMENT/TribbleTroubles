using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public bool canJump = true;
    public float speed = 3;
    private Rigidbody rb;

    Keyboard kb = Keyboard.current;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        rb.linearVelocity = new Vector3(Input.GetAxis("Horizontal") * speed, rb.linearVelocity.y, rb.linearVelocity.z);

        if (kb != null)
        {
            if (kb.spaceKey.wasPressedThisFrame && canJump)
            {
                rb.linearVelocity = new Vector3(rb.linearVelocity.x, speed * 1.5f, rb.linearVelocity.z);
                canJump = false;
            }
            
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        canJump = true;
    }
}
