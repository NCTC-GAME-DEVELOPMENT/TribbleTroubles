using UnityEngine;
using UnityEngine.InputSystem;

//Manages the fuctionality of the player pawn, particularly the gimmicks (lens)
//Reusuing this a player movement fine tuning -Morgan
public class PlayerManager : MonoBehaviour
{
    
    public int InputNumber = 0;

    public float speed = 3;
    public float jump = 5;

    private Rigidbody rb;


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

    public InteractableObject currentObject; 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput(InputNumber);

        rb.linearVelocity = Vector3.zero;

        MovePlayer(leftThumbStick.x);

        PlayerJump(northButton);


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
        rb.linearVelocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.linearVelocity.y);
    }
    
    public void PlayerJump(float value)
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jump * 2);
        Debug.Log("Jump");
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
