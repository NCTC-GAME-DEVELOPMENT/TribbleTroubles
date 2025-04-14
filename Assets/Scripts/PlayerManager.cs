using UnityEngine;
using UnityEngine.InputSystem;

//Manages the fuctionality of the player pawn, particularly the gimmicks (lens)
//Reusuing this a player movement fine tuning -Morgan
public class PlayerManager : MonoBehaviour
{
    
    public int InputNumber = 0;

    public float speed = 3;
    public float jump = 5;
    public float additionalGravity = .05f; 
    public Transform EyesObject; 

    public InteractableObject currentObject;

    private Rigidbody rb;

    public float VelocityUnderIsGroundedValue = 0.1f; 

    //Input Varibles
    // Jump
    bool northButton = false;
    bool eastButton = false;
    bool westButton = false;
    // Interact
    bool southButton = false; 

    Vector2 leftThumbStick = Vector2.zero;
    bool leftTriggerButton = false;
    bool rightTriggerButton = false;

    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        


        GetInput(InputNumber);

        //rb.linearVelocity = Vector3.zero;

        MovePlayer(leftThumbStick.x);

        if (northButton)
        {
            PlayerStartJump();
        }
            


        if (leftTriggerButton)
        {
            GameManager.Instance.CycleLensMinus();
        }
        if (rightTriggerButton)
        {
            GameManager.Instance.CycleLensPlus();
        }

        if (southButton)
        {
            if (currentObject != null)
            {
                currentObject.PerformInteraction(); 
            }
        }
    }

    void GetInput(int PlayerInputNumber)
    {
        ClearInputs(); 

        if (PlayerInputNumber == 0) { GetInputPlayer0(); return; }

        if (PlayerInputNumber == 1) { GetInputPlayer1(); return; }
    }

    void ClearInputs()
    {
        leftThumbStick = Vector2.zero;
        northButton = false;
        eastButton = false;
        westButton = false;
        leftTriggerButton = false;
        rightTriggerButton = false;
    }

    public void MovePlayer(float value)
    {
        Vector3 newVelocity = rb.linearVelocity;
        newVelocity.x = value * speed;
        
        if (!IsGrounded())
        {
            newVelocity.y -= additionalGravity;
        }
        rb.linearVelocity = newVelocity;

        // flip the eyes to face direction we're moving. 
        if (value == 0 )
        {
            // don't flip eyes if value is zero
            return; 
        }
        Vector3 newScale = EyesObject.localScale; 
        if (value >= 0)
        {
            newScale.x = 1;
        }
        else
        {
            newScale.x = -1; 
        }
        EyesObject.localScale = newScale; 
        

    }
    
    public void PlayerStartJump()
    {
        if (!IsGrounded())
        {
            return; 
        }

        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jump * 2);
        Debug.Log("Jump");
    }

    public bool IsGrounded()
    {
        return (Mathf.Abs(rb.linearVelocity.y) < VelocityUnderIsGroundedValue); 
    }

    public void GetInputPlayer0()
    {
        Gamepad gpad = Gamepad.current;
        if (gpad != null)
        {
            leftThumbStick = gpad.leftStick.ReadValue();
            northButton = gpad.buttonNorth.wasPressedThisFrame;
            southButton = gpad.buttonSouth.wasPressedThisFrame; 
            eastButton = gpad.buttonEast.wasPressedThisFrame;
            westButton = gpad.buttonWest.wasPressedThisFrame; 
            leftTriggerButton = gpad.leftShoulder.wasPressedThisFrame;
            rightTriggerButton = gpad.rightShoulder.wasPressedThisFrame;
        }
    }

    public void GetInputPlayer1()
    {
        Keyboard kb = Keyboard.current;
        if (kb != null)
        {
            if (kb.dKey.isPressed) { leftThumbStick.x = 1; }
            if (kb.aKey.isPressed) { leftThumbStick.x = -1; }

            leftTriggerButton = kb.qKey.wasPressedThisFrame;
            rightTriggerButton = kb.eKey.wasPressedThisFrame;

            northButton = kb.wKey.wasPressedThisFrame;
            southButton = kb.nKey.wasPressedThisFrame;
        }
    }
}
