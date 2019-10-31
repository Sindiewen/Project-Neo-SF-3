using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // variables
    public float moveSpeed = 5f;



    // Private variables

    // Player movement variables
    private Vector2 moveDirection;

    // Component references
    private Rigidbody2D rb2d;       // Reference to the player rigidbody component   


    private void Start()
    {
        // Initialize components
        rb2d = GetComponent<Rigidbody2D>();
    }


    /// <summary>
    /// UPdates every frame
    /// </summary>
    private void Update()
    {
        // Gets player movement
        getInput();
    }

    /// <summary>
    /// Fixed update function
    /// runs every frame, but executed on a fixed timer
    /// </summary>
    private void FixedUpdate()
    {
        initiatiteMovement();
    }
    


    // Player Movement
    // ----------------------------------------------------------

    /// <summary>
    /// Gets any input from the player
    /// </summary>
    private void getInput()
    {
        // Get horizontal and vertical input
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.y = Input.GetAxisRaw("Vertical");
    }

    private void initiatiteMovement()
    {
        // Move player position based on the current player position + the direction the playe ris moving,
        // Then multiply that by the speed the player will move, and then multiplay that by deltaTime to ensure
        // it's moving at realtime
        rb2d.MovePosition(rb2d.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
    }

}
