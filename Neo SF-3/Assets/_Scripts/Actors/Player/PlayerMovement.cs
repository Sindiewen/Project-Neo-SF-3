using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

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

    [Header("Player Movement Values")]
    public float moveSpeed = 5f;        //How fast the player will move

    [Header("InputManager References")]
    public string moveHorizontal = "Horizontal";
    public string moveVertical = "Vertical";
    public string attackKey = "Fire1";



    // Private variables
    // ---------------------------------------------

    // Component references
    private Rigidbody2D rb2d;           // Reference to the player rigidbody component   


    // Player input data
    private Vector2 moveDirection;
    private bool isAttacking;


    #endregion


    #region Private Methods


    /// <summary>
    /// Unity start method
    /// 
    /// Runs once when the scene starts
    /// </summary>
    private void Start()
    {
        // Initialize components
        rb2d = GetComponent<Rigidbody2D>();

        // Initialize the player's input values
        // If the player is player two, append "_p2" at the end to say it's a player 2
        if (player_number == PLAYER_NUMBER.PLAYER_TWO)
        {
            moveHorizontal += "_p2";
            moveVertical += "_p2";
            attackKey += "_p2";
        }
        // Player 1 = "_p1"
        else
        {
            moveHorizontal += "_p1";
            moveVertical += "_p1";
            attackKey += "_p1";
        }

    }


    /// <summary>
    /// Unity update method
    ///
    /// UPdates every frame
    /// </summary>
    private void Update()
    {
        // Gets player movement
        getInput();

        // Initiate player input
        // ----------------------------
        initiateAttack();
    }

    /// <summary>
    /// Fixed update function
    /// runs every frame, but executed on a fixed timer
    /// </summary>
    private void FixedUpdate()
    {
        // Iniitate player movement (NOTE: Unity Physics must be kept inside of FixedUpdate()
        // to ensure physics are not tied to the frame rate)
        initiatiteMovement();
    }




    // Parse playerInput
    // ------------------------------------------------------------

    /// <summary>
    /// Gets any input from the player
    /// </summary>
    private void getInput()
    {

        // Move the player
        // Get horizontal and vertical input
        moveDirection.x = Input.GetAxisRaw(moveHorizontal);
        moveDirection.y = Input.GetAxisRaw(moveVertical);

        // check for attackInput
        // If the player presses the attack key, set attacking to true
        isAttacking = Input.GetButtonDown(attackKey);
    }


    // Initiate player Input
    // ----------------------------------------------------------

    /// <summary>
    /// Initiates player movement
    /// </summary>
    private void initiatiteMovement()
    {
        // Move player position based on the current player position + the direction the playe ris moving,
        // Then multiply that by the speed the player will move, and then multiplay that by deltaTime to ensure
        // it's moving at realtime
        rb2d.MovePosition(rb2d.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
    }

    /// <summary>
    /// Initiates player attack
    /// </summary>
    private void initiateAttack()
    {
        // If the player has pressed the attack key on the same frame
        if (isAttacking)
        {
            // Initiate the player attack

        }
    }

    #endregion

}
