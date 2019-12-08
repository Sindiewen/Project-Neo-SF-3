using Com.LuisPedroFonseca.ProCamera2D;
using UnityEngine;

public class PlayerAttributesController : MonoBehaviour
{

    // Variables
    #region Variables
    // Public Variables
    // --------------------------------
    [Header("Player Attributes")]
    public int playerHealth;            // Current player health
    public int playerHealthMax;         // Max player health
    public float invulnerabilityTimer;  // How long the player is invulnerable after hit
    public float staggerTimer;          // How long the player is staggered
    public float playerRespawnTimer;    // How long before the player can respawn after death


    [Header("Player Combat Values")]
    public int AttackStrength;          // Player attack strength
    public float comboResetCooldown;    // How long it takes before the attack's can be used again outside of combo
    public float midComboAtkCooldown;   // How long it takes before the next attack in the combo chain can be initiated

    [Header("Player Partner Attributes")]
    public PlayerAttributesController partner;
    public ProCamera2D cam;


    // Private Variables
    // ---------------------------------

    // invul timer
    [SerializeField] private float invulTimer = 0;       // Timer to decrement invul
    private bool isInvul = false;
    [SerializeField] private float staggeredTimer = 0;
    private bool isStaggered = false;
    [SerializeField] private float respawnTimer = 0;
    private bool isPlayerDead = false;

    #endregion


    // Private Methods
    // ------------------------------------
    #region private Methods

    private void Start()
    {
        // Get the camera
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ProCamera2D>();
    }

    /// <summary>
    /// Unity update method
    /// 
    /// Runs once every frame
    /// </summary>
    private void Update()
    {
        // Resets invl timer
        if (invulTimer >= 0 && isInvul) resetInvul();
        if (staggeredTimer >= 0 && isStaggered) resetStagger();
        if (respawnTimer >= 0 && isPlayerDead) resetRespawn();
    }

    // stagger invul states
    // ------------------------------------------

    /// <summary>
    /// Set invul state
    /// </summary>
    private void setInvul()
    {
        isInvul = true;
        invulTimer = invulnerabilityTimer;
    }

    /// <summary>
    /// Sets stagger state
    /// </summary>
    private void setStagger()
    {
        staggeredTimer = staggerTimer;
        isStaggered = true;
    }

    /// <summary>
    /// Sets player to dead, starts respawn timer
    /// </summary>
    private void setRespawn()
    {
        respawnTimer = playerRespawnTimer;
        isPlayerDead = true;
    }

    /// <summary>
    /// Timer decrements to reset the invulnerability timer
    /// </summary>
    private void resetInvul()
    {
        // decrement timer
        invulTimer -= Time.deltaTime;

        // Set invul to false when timer runs
        if (invulTimer <= 0)
        {
            isInvul = false;
        }
    }

    /// <summary>
    /// Timer decrements to reset the stagger
    /// </summary>
    private void resetStagger()
    {
        // decrement timer
        staggeredTimer -= Time.deltaTime;

        // set stagger  to false is timer runs out
        if (staggeredTimer <= 0)
        {
            isStaggered = false;
        }
    }

    /// <summary>
    /// Timer decrements to allow for respawning
    /// </summary>
    private void resetRespawn()
    {
        respawnTimer -= Time.deltaTime;

        if (respawnTimer <= 0)
        {
            respawn();
        }
        Debug.Log("Respawning in " + (int)respawnTimer);
    }

    #endregion

    // public Methods
    // ------------------------------------
    #region public Methods

    /// <summary>
    /// Player takes damage 
    /// </summary>
    /// <param name="damageToTake"></param>
    public void takeDamage(int damageToTake)
    {
        if (!isInvul)
        {
            // player invulnerable
            setInvul();

            // player staggered
            setStagger();

            // Take damage
            playerHealth -= damageToTake;

            // Disable player if dead
            if (playerHealth <= 0)
            {
                death();
                setRespawn();
                //gameObject.SetActive(false);
            }
        }
    }

    /// <summary>
    /// Restores health based on an item the player picks up
    /// </summary>
    /// <param name="healthToRestore"></param>
    public void restoreHealth(int healthToRestore)
    {
        // if player picks up health restore item and is low enough health to restore it
        if (playerHealth < playerHealthMax)
        {
            // destroy pickup, restore health
            // Player can overheal a little bit
            playerHealth += healthToRestore;
        }
    }

    /// <summary>
    /// Sets called if player dies
    /// </summary>
    public void death()
    {
        isPlayerDead = true;
        // Kill player
        Debug.Log("player died, respawning player");
        //gameObject.SetActive(false);
        // Remove player from camera
        cam.RemoveCameraTarget(this.transform);
    }

    /// <summary>
    /// respawns player when they've died
    /// </summary>
    public void respawn()
    {
        Debug.Log("Respawning Player now");
        // Return player object from dead
        //gameObject.SetActive(true);
        isPlayerDead = false;

        // restore health
        playerHealth = playerHealthMax;

        // set invulnerable
        setInvul();

        // move player next to partner
        transform.position = partner.transform.position + Vector3.up;

        // add player to camera
        cam.AddCameraTarget(this.transform);
    }


    #endregion


    #region getters/setters

    /// <summary>
    /// Returns if player is invulnerable
    /// </summary>
    public bool playerInvulnerable
    {
        get { return isInvul; }
    }

    /// <summary>
    /// Returns if player is staggered
    /// </summary>
    public bool playerStaggered
    {
        get { return isStaggered; }
    }

    /// <summary>
    /// Returns if is dead
    /// </summary>
    public bool PlayerDied
    {
        get { return isPlayerDead; }
    }

    #endregion
}
