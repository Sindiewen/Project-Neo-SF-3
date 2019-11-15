using UnityEngine;


/// <summary>
/// Tether 2 or more people based on set parameters
/// </summary>
public class PlayerTetherController : MonoBehaviour
{
    // Variables
    // -----------------------------------
    #region Variables
    // public variables
    public PlayerInputController[] players;             // Lists all players
    public float playerMaxDistance = 20;                // The max distance between each player

    // Private variables
    [SerializeField] private float playerDistanceTotal;          // Distance between both players


    #endregion

    // Private Methods
    // ------------------------------------
    #region Private Methods

    /// <summary>
    /// Unity update method
    /// 
    /// Updates every frame
    /// </summary>
    private void Update()
    {
        // Gets both player's locations, and their distance between the two
        playerDistanceTotal = Vector2.Distance(players[0].transform.position, players[1].transform.position);

        // If max distance is greater than the current player distance, then stop
        // input away from the player
        if (playerDistanceTotal > playerMaxDistance)
        {
            Debug.Log("Player's are current at or above their max distance");
        }
    }

    #endregion

    // Public Methods
    // ------------------------------------
    #region Public Methods

    #endregion

}
