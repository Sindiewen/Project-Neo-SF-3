﻿using UnityEngine;

/// <summary>
/// COntrols the input on where it will go
/// </summary>
public class PlayerInputController : MonoBehaviour
{

    // Variables
    #region Variables

    // Private variables

    // Component references
    private PlayerInputManager inputManager;
    private PlayerMovement playerMovement;
    private PlayerCombatController playerCombat;


    #endregion


    // Private Methods
    #region private Methods

    /// <summary>
    /// Unity start method
    /// 
    /// Runs at start of initialization
    /// </summary>
    private void Start()
    {
        // Defines the component references
        inputManager = GetComponent<PlayerInputManager>();
        playerMovement = GetComponent<PlayerMovement>();
        playerCombat = GetComponent<PlayerCombatController>();
    }

    /// <summary>
    /// Unity Update method
    /// 
    /// Runs every frame
    /// </summary>
    private void Update()
    {
        // If player attacks, initiate atttack
        if (inputManager.IsAttacking)
            playerCombat.initiateAttack(playerMovement.FacingDirection);
        playerCombat.FacingDir = playerMovement.FacingDirection;
    }

    /// <summary>
    /// Unity fixed update method
    /// 
    /// Runs once per frame, but executed on a fixed interval
    /// Do physics here
    /// </summary>
    private void FixedUpdate()
    {
        // Iniitate player movement (NOTE: Unity Physics must be kept inside of FixedUpdate()
        // to ensure physics are not tied to the frame rate)
        if (inputManager.IsAttacking || playerCombat.cooldownTimer <= 0)
            playerMovement.initiatiteMovement(inputManager.MoveDirection);
    }


    #endregion

}
