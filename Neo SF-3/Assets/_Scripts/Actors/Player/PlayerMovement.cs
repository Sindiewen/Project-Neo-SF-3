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

    #endregion

    #region Public Methods 

    // Initiate player Input
    // ----------------------------------------------------------

    /// <summary>
    /// Initiates player movement
    /// </summary>
    public void initiatiteMovement(Vector2 moveDirection)
    {
        // Move player position based on the current player position + the direction the playe ris moving,
        // Then multiply that by the speed the player will move, and then multiplay that by deltaTime to ensure
        // it's moving at realtime
        rb2d.MovePosition(rb2d.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
    }


    #endregion

}
