using UnityEngine;


/// <summary>
/// Manages and defines the input manager of the player
/// 
/// 
/// </summary>
public class PlayerInputManager : MonoBehaviour
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

    [Header("InputManager References")]
    [SerializeField] private string moveHorizontal = "Horizontal";
    [SerializeField] private string moveVertical = "Vertical";
    //[SerializeField] private string attackKey = "Fire1";
    [SerializeField] private KeyCode attackKey;


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
        // Initialize the player's input values
        // If the player is player two, append "_p2" at the end to say it's a player 2
        if (player_number == PLAYER_NUMBER.PLAYER_TWO)
        {
            moveHorizontal += "_p2";
            moveVertical += "_p2";
            attackKey = KeyCode.Joystick2Button0;
        }
        // Player 1 = "_p1"
        else
        {
            moveHorizontal += "_p1";
            moveVertical += "_p1";
            attackKey = KeyCode.Joystick1Button0;
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

        // Move the player
        // Get horizontal and vertical input
        moveDirection.x = Input.GetAxisRaw(moveHorizontal);
        moveDirection.y = Input.GetAxisRaw(moveVertical);

        // check for attackInput
        // If the player presses the attack key, set attacking to true
        //isAttacking = Input.GetButtonDown(attackKey);
        isAttacking = Input.GetKeyDown(attackKey);
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

    #endregion

}