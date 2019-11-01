using UnityEngine;

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
    public string moveHorizontal = "Horizontal";
    public string moveVertical = "Vertical";
    public string attackKey = "Fire1";


    // Player input data
    [HideInInspector] public Vector2 moveDirection;
    [HideInInspector] public bool isAttacking;


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


    #endregion

}