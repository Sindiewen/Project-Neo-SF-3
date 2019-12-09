using UnityEngine;


/// <summary>
/// Manages and defines the input manager of the player
/// 
/// 
/// </summary>
public class PlayerInputManager : MonoBehaviour
{
    /// <summary>
    /// TODO: Prepare code for the new unity input system
    /// </summary>

    // Enums
    #region enums

    // Defines which player this player is
    public enum PLAYER_NUMBER
    {
        PLAYER_ONE,
        PLAYER_TWO
    };


    #endregion

    // variables
    #region Variables

    // public Variables
    // ---------------------------------------------
    [Header("Player Number")]
    public PLAYER_NUMBER player_number; // Defines which number the player is

    [Header("Gamepad Icons")]
    //public Sprite[] A_Button;
    public GameObject P2_iconCanvas;
    public GameObject P2_HealthBar;
    
    // Input definitions
    //private KeyCode attackKey;
    private Keys attackKey;
    //private KeyCode sprintKey;
    private Keys sprintKey;

    // Player input data
    private bool p2ControlState = false;
    private bool canControlP2 = false;
    private bool dropOutPlayer = false;
    private bool canMove = true;
    private Vector2 moveDirection;
    private bool isAttacking;
    private bool isSprinting;
    private bool killPlayer;

    // Timers
    private float flashTimer = 1.0f;
    private float flashingTimer;

    // component references
    private BoxCollider2D box2d;

    #endregion


    #region Private Methods


    /// <summary>
    /// Unity start method
    /// 
    /// Runs once when the scene starts
    /// </summary>
    private void Start()
    {
        // Initializes cinput
        cInput.Init();

        box2d = GetComponent<BoxCollider2D>();

        // Player must join first
        if (player_number == PLAYER_NUMBER.PLAYER_TWO)
        {
            canMove = false;
            flashingTimer = flashTimer;
            P2_iconCanvas.SetActive(true);
            box2d.enabled = false;
        }

        // Define controls
        defineControlscInput();
    }


    /// <summary>
    /// Unity update method
    ///
    /// UPdates every frame
    /// </summary>
    private void Update()
    {
        // Gets input from the player
        getInput();

        if (player_number == PLAYER_NUMBER.PLAYER_TWO && !p2ControlState)
            flashA_Button();
    }

    /// <summary>
    /// Defines controls
    /// </summary>
    private void defineControlscInput()
    {

        // Initialize the player's input values
        // If the player is player two, append "_p2" at the end to say it's a player 2
        if (player_number == PLAYER_NUMBER.PLAYER_TWO)
        {
            if (!p2ControlState)
            {
                P2_HealthBar.SetActive(false);
                P2_iconCanvas.SetActive(true);
                box2d.enabled = false;


                Debug.Log("Player 2 not in control");
                cInput.SetKey("ActivePlayer", Keys.Xbox2A, Keys.Comma);
            }
            else
            {
                P2_HealthBar.SetActive(true);
                P2_iconCanvas.SetActive(false);
                box2d.enabled = true;

                Debug.Log("Player 2 in control");
                cInput.SetKey("Up_p2", Keys.UpArrow, Keys.Xbox2LStickUp);
                cInput.SetKey("Down_p2", Keys.DownArrow, Keys.Xbox2LStickDown);
                cInput.SetKey("Left_p2", Keys.LeftArrow, Keys.Xbox2LStickLeft);
                cInput.SetKey("Right_p2", Keys.RightArrow, Keys.Xbox2LStickRight);
                cInput.SetKey("Attack_p2", Keys.Comma, Keys.Xbox2X);
                cInput.SetKey("Sprint_p2", Keys.Period, Keys.Xbox2TriggerRight);
                cInput.SetKey("DropOut", Keys.RightBracket, Keys.Xbox2Back);

                cInput.SetAxis("Horizontal_p2", "Left_p2", "Right_p2");
                cInput.SetAxis("Vertical_p2", "Down_p2", "Up_p2");
            }

        }
        // Player 1 = "_p1"
        else
        {
            cInput.SetKey("Up_p1", Keys.W, Keys.Xbox1LStickUp);
            cInput.SetKey("Down_p1", Keys.S, Keys.Xbox1LStickDown);
            cInput.SetKey("Left_p1", Keys.A, Keys.Xbox1LStickLeft);
            cInput.SetKey("Right_p1", Keys.D, Keys.Xbox1LStickRight);
            cInput.SetKey("Attack_p1", Keys.C, Keys.Xbox1X);
            cInput.SetKey("Sprint_p1", Keys.V, Keys.Xbox1TriggerRight);
            cInput.SetKey("kill", Keys.Q);

            cInput.SetAxis("Horizontal_p1", "Left_p1", "Right_p1");
            cInput.SetAxis("Vertical_p1", "Down_p1", "Up_p1");
        }
    }

    // Parse playerInput
    // ------------------------------------------------------------

    /// <summary>
    /// Gets any input from the player
    /// </summary>
    private void getInput()
    {
        if (player_number == PLAYER_NUMBER.PLAYER_ONE)
        {
            canMove = true;
            // Move the player
            // Get horizontal and vertical input
            moveDirection.x = cInput.GetAxisRaw("Horizontal_p1");
            moveDirection.y = cInput.GetAxisRaw("Vertical_p1");

            // check for attackInput
            // If the player presses the attack key, set attacking to true
            //isAttacking = Input.GetButtonDown(attackKey);
            isAttacking = cInput.GetKeyDown("Attack_p1");
            isSprinting = cInput.GetKey("Sprint_p1");
            killPlayer = cInput.GetKey("kill");
        }
        else    // Player 2
        {
            if (p2ControlState)
            {
                canMove = true;
                // Move the player
                // Get horizontal and vertical input
                moveDirection.x = cInput.GetAxisRaw("Horizontal_p2");
                moveDirection.y = cInput.GetAxisRaw("Vertical_p2");

                // check for attackInput
                // If the player presses the attack key, set attacking to true
                isAttacking = cInput.GetKeyDown("Attack_p2");
                isSprinting = cInput.GetKey("Sprint_p2");
                dropOutPlayer = cInput.GetKeyDown("DropOut");

                // To drop out player 2
                if (dropOutPlayer)
                {
                    p2ControlState = false;
                    canControlP2 = false;
                    defineControlscInput();
                }
            }
            else
            {
                // At start, p2 cannot control p2. when a is pressed, allow control
                canMove = false;
                canControlP2 = cInput.GetKeyDown("ActivePlayer");

                if (canControlP2)
                {
                    p2ControlState = true;

                    // define player 2 controls
                    defineControlscInput();
                }
            }
        }
    }

    private void flashA_Button()
    {
        // Flash ui Element
        if (flashingTimer <= 0)
        {
            flashingTimer = flashTimer;
            P2_iconCanvas.SetActive(!P2_iconCanvas.activeSelf);
        }
        // Decrement timer
        else
        {
            flashingTimer -= Time.deltaTime;
        }
    }


    #endregion

    // Getters and Setters
    #region Getters/Setters

    // Player input data
    public bool P2ControlState
    {
        get { return p2ControlState; }
    }

    public bool CanControlP2
    {
        get { return canControlP2; }
    }
    public bool CanMove
    {
        get { return canMove; }
    }

    // Get all input data
    public Vector2 MoveDirection
    {
        get { return moveDirection; }
    }

    public bool IsAttacking
    {
        get { return isAttacking; }
    }

    public bool IsSprinting
    {
        get { return isSprinting; }
    }

    public bool KillPlayer
    {
        get { return killPlayer; }
    }

    #endregion

}