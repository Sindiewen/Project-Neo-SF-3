using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // variables
    #region Variables

    // public Variables
    // ---------------------------------------------

    [Header("Player Movement Values")]
    public float moveSpeed = 5f;        //How fast the player will move
    // Private variables
    // ---------------------------------------------

    // Component references
    private PlayerInputManager inputmanager;    // Reference to the player input manager component
    private Rigidbody2D rb2d;                   // Reference to the player rigidbody component   

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
        inputmanager = GetComponent<PlayerInputManager>();
        rb2d = GetComponent<Rigidbody2D>();
    }


    /// <summary>
    /// Unity update method
    ///
    /// UPdates every frame
    /// </summary>
    private void Update()
    {
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
        rb2d.MovePosition(rb2d.position + inputmanager.moveDirection * moveSpeed * Time.fixedDeltaTime);
    }

    /// <summary>
    /// Initiates player attack
    /// </summary>
    private void initiateAttack()
    {
        // If the player has pressed the attack key on the same frame
        if (inputmanager.isAttacking)
        {
            // Initiate the player attack

        }
    }

    #endregion

}
