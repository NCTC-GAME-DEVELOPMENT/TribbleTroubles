using UnityEngine;
using UnityEngine.InputSystem;

//Proto movement. Works but needs fine tuning

public class PlayerMovement : MonoBehaviour
{

    public bool canJump = true;
    public float speed = 3;
    public bool RedLens;
    public bool YellowLens;
    public bool BlueLens;
    private Rigidbody rb;

    public int lensColor = 0;

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
                rb.linearVelocity = new Vector3(rb.linearVelocity.x, speed * 2f, rb.linearVelocity.z);
                canJump = false;
            }
            
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        canJump = true;
    }

    /*public void ChangeLens()
    {
        if ()
        {
            lensColor--;

            if (lensColor < 0)
            {
                lensColor = 3;
            }
        }

        if ()
        {
            lensColor++;

            if (lensColor > 3)
            {
                lensColor = 0;
            }
        }
    }*/
    public void SelectRed()
    {
        RedLens = true;
        YellowLens = false;
        BlueLens = false;
    }
}
