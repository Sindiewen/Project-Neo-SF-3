using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatController : MonoBehaviour
{

    // Variables
    // --------------------------------------------------
    #region Variables

    // public variables
    public Rect[] attackRect;           // Array of attack rects: will store 4 attack locations
    public Vector2 attackDirection;     // Direction attack will go
    public float attackDistance;        // Distance of the attack
    public LayerMask collisionMask;     // What the attacks can hit using Unity's layer system


    // Private variables

    [SerializeField] private int lastFacingDir;          // Srores the last facing direction

    // Component references
    private PlayerAttributesController playerAttributesController;

    #endregion


    #region public Methods

    /// <summary>
    /// Initiates player attack
    /// </summary>
    public void initiateAttack(int facingDirection)
    {
        // Initiates player attack
        Debug.Log("Player " + this.name + " Attacking");

        /*
         * Player attack direction is determined based on the enum set in Player movement
         * for facing direction.
         * If the player is facing up, the player will attack upwards, and
         * so forth to the other directions.
         */


        // -----------------------------------------------------------------
        // this code is smiliar to code I use on my personal proejcts for combat.
        // It's kinda a mess, but it works really, really well

        // Get current vector2 location of where the attack will start
        Vector2 rayOrigin = (Vector2)transform.position + attackRect[facingDirection].center;

        // Create raycast box for chcking if enemy has been hit
        RaycastHit2D[] hit = Physics2D.BoxCastAll(rayOrigin, attackRect[facingDirection].size, 0, attackDirection, attackDistance, collisionMask);


        // Have player stop moving when attacking
        // Start attack animation
        // Have enemy enter invul frames
        // end attack animq
        // remove raycast box

        // If has hit enemies
        if (hit.Length > 0)
        {
            // Successfully hit enemies

            // Create list of enemies to attack
            List<EnemyAttributes> enemyList = new List<EnemyAttributes>();

            // Stores enemyes into list
            for (int i = 0; i < hit.Length; ++i)
            {
                enemyList.Add(hit[i].transform.GetComponent<EnemyAttributes>());
            }

            // Deal damage to the enemies
            for (int i = 0; i < enemyList.Count; ++i)
            {
                enemyList[i].takeDamage(playerAttributesController.AttackStrength);
            }
        }   

    }

    #endregion


    // Private class methods
    // -------------------------------------------------
    #region private Methods

    /// <summary>
    /// Unity start method
    /// 
    /// Runs at initialization
    /// </summary>
    private void Start()
    {
        // Get component references
        playerAttributesController = GetComponent<PlayerAttributesController>();
    }



    // for drawing gizmos
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.matrix = Matrix4x4.TRS((Vector2)this.transform.position + attackRect[lastFacingDir].center, this.transform.rotation, Vector3.one);
        Gizmos.DrawWireCube(Vector2.zero, attackRect[lastFacingDir].size);
        Gizmos.matrix = Matrix4x4.TRS((Vector2)this.transform.position + attackRect[lastFacingDir].center + (attackDirection.normalized * attackDistance), this.transform.rotation, Vector3.one);
        Gizmos.DrawWireCube(Vector2.zero, attackRect[lastFacingDir].size);
        Gizmos.color = Color.cyan;
        Gizmos.matrix = Matrix4x4.TRS((Vector2)this.transform.position + attackRect[lastFacingDir].center, Quaternion.identity, Vector3.one);
        Gizmos.DrawLine(Vector2.zero, attackDirection.normalized * attackDistance);

    }
    #endregion


    #region getters/setters

    public int FacingDir
    {
        set { lastFacingDir = value; }
    }

    #endregion

}
