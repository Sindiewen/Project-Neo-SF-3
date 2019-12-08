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

    [Header("InputManager References")]
    [SerializeField] private bool usingKeyboard;

    [Header("Movement")]
    //[SerializeField] private string moveHorizontal = "Horizontal";
    //[SerializeField] private string moveVertical = "Vertical";

    [Header("Keyboard Input")]
    //[SerializeField] private KeyCode attackKeyKB;
    [SerializeField] private Keys attackKeyKB;
    //[SerializeField] private KeyCode sprintKeyKB;
    [SerializeField] private Keys sprintKeyKB;

    [Header("Gamepad Input")]
    //[SerializeField] private KeyCode attackKeyGP;
    [SerializeField] private Keys attackKeyGP;
    //[SerializeField] private KeyCode sprintKeyGP;
    [SerializeField] private Keys sprintKeyGP;


    // Input definitions
    //private KeyCode attackKey;
    private Keys attackKey;
    //private KeyCode sprintKey;
    private Keys sprintKey;

    // Player input data
    private Vector2 moveDirection;
    private bool isAttacking;
    private bool isSprinting;
    private bool killPlayer;


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

        // Initialize the player's input values
        // If the player is player two, append "_p2" at the end to say it's a player 2
        if (player_number == PLAYER_NUMBER.PLAYER_TWO)
        {
            cInput.SetKey("Up_p2", Keys.UpArrow, Keys.Xbox2LStickUp);
            cInput.SetKey("Down_p2", Keys.DownArrow, Keys.Xbox2LStickDown);
            cInput.SetKey("Left_p2", Keys.LeftArrow, Keys.Xbox2LStickLeft);
            cInput.SetKey("Right_p2", Keys.RightArrow, Keys.Xbox2LStickRight);
            cInput.SetKey("Attack_p2", Keys.Comma, Keys.Xbox2X);
            cInput.SetKey("Sprint_p2", Keys.Period, Keys.Xbox2TriggerRight);

            cInput.SetAxis("Horizontal_p2", "Left_p2", "Right_p2");
            cInput.SetAxis("Vertical_p2", "Down_p2", "Up_p2");

            /*
            moveHorizontal += "_p2";
            moveVertical += "_p2";
            if (!usingKeyboard)
            {
                attackKey = attackKeyGP;
                sprintKey = sprintKeyGP;
            }
            else
            {
                attackKey = attackKeyKB;
                sprintKey = sprintKeyKB;
            }
            */

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
            /*
            moveHorizontal += "_p1";
            moveVertical += "_p1";
            if (!usingKeyboard)
            {
                attackKey = attackKeyGP;
                sprintKey = sprintKeyGP;
            }
            
            else
            {
                attackKey = attackKeyKB;
                sprintKey = sprintKeyKB;
            }
            */
        }

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
            // Move the player
            // Get horizontal and vertical input
            /*
            moveDirection.x = Input.GetAxisRaw(moveHorizontal);
            moveDirection.y = Input.GetAxisRaw(moveVertical);
            */
            moveDirection.x = cInput.GetAxisRaw("Horizontal_p1");
            moveDirection.y = cInput.GetAxisRaw("Vertical_p1");

            // check for attackInput
            // If the player presses the attack key, set attacking to true
            //isAttacking = Input.GetButtonDown(attackKey);
            /*
            isAttacking = Input.GetKeyDown(attackKey);
            isSprinting = Input.GetKey(sprintKey);
            */
            isAttacking = cInput.GetKeyDown("Attack_p1");
            isSprinting = cInput.GetKey("Sprint_p1");
            killPlayer = cInput.GetKey("kill");
        }
        else
        {
            // Move the player
            // Get horizontal and vertical input
            /*
            moveDirection.x = Input.GetAxisRaw(moveHorizontal);
            moveDirection.y = Input.GetAxisRaw(moveVertical);
            */
            moveDirection.x = cInput.GetAxisRaw("Horizontal_p2");
            moveDirection.y = cInput.GetAxisRaw("Vertical_p2");

            // check for attackInput
            // If the player presses the attack key, set attacking to true
            //isAttacking = Input.GetButtonDown(attackKey);
            /*
            isAttacking = Input.GetKeyDown(attackKey);
            isSprinting = Input.GetKey(sprintKey);
            */
            isAttacking = cInput.GetKeyDown("Attack_p2");
            isSprinting = cInput.GetKey("Sprint_p2");
        }
        
    }


    #endregion

    // Getters and Setters
    #region Getters/Setters

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