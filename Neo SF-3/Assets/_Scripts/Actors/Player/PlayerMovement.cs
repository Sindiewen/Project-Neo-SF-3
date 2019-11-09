using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Enums
    #region Enums

    // Enum of current facing direction
    public enum PLAYER_FACING_DIRECTION
    {
        UP = 0, DOWN = 1, LEFT = 2, RIGHT = 3
    };

    #endregion

    // variables
    #region Variables

    // public Variables
    // ---------------------------------------------

    [Header("Player Movement Values")]
    public float moveSpeed = 5f;                    // How fast the player will move
    [SerializeField] private PLAYER_FACING_DIRECTION facingDirection; // Stores the current facing direction
    // Private variables
    // ---------------------------------------------

    // Component references
    private PlayerInputManager inputmanager;    // Reference to the player input manager component
    private Rigidbody2D rb2d;                   // Reference to the player rigidbody component   
    [SerializeField] private Animator anim;     // Reference to child animator

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

        // Setting facing direction
        facingDirection = PLAYER_FACING_DIRECTION.UP;
        anim.SetFloat("Vertical", 1);
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

        // Player moving and facing upwards, moving up diagonals left or right
        if (moveDirection.y > 0 && (moveDirection.x <= 0.5f || moveDirection.x >= -0.5f))
        {
            facingDirection = PLAYER_FACING_DIRECTION.UP;
        }
        else if (moveDirection.y < 0 && (moveDirection.x <= 0.5f || moveDirection.x >= -0.5f))
        {
            facingDirection = PLAYER_FACING_DIRECTION.DOWN;
        }
        // If player if moving anf facing right, moving right diagonals up or down
        else if (moveDirection.x > 0 && (moveDirection.y <= 0.5f || moveDirection.y >= -0.5f))
        {
            facingDirection = PLAYER_FACING_DIRECTION.RIGHT;
        }
        else if (moveDirection.x < 0 && (moveDirection.y <= 0.5f || moveDirection.y >= -0.5f))
        {
            facingDirection = PLAYER_FACING_DIRECTION.LEFT;
        }

        rb2d.MovePosition(rb2d.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
        anim.SetFloat("Horizontal", moveDirection.x);
        anim.SetFloat("Vertical", moveDirection.y);

    }


    #endregion

    #region getters/setters

    // Get player facing direction
    public int FacingDirection
    {
        get { return (int)facingDirection; }
    }

    #endregion

}
