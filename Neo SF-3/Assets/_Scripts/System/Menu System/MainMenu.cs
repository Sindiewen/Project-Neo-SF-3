using UnityEngine;

public class MainMenu : MonoBehaviour
{
    #region Variables

    // Public VAriables
    // ---------------------------------
    public GameObject mainMenuUI;
    public GameObject playerUI;

    // private variables
    // ---------------------------------
    private bool isPaused = true;


    #endregion

    #region public Methods


    /// <summary>
    /// Plyaer presses start game, hides main menu ui, activates game
    /// </summary>
    public void startNewGame()
    {
        // Deactivate main menu
        mainMenuUI.SetActive(false);
        playerUI.SetActive(true);

        // return control to the player
        isPaused = false; 
    }


    #endregion


    #region getters/setters


    public bool IsPaused
    {
        get { return isPaused; }
    }

    #endregion
}
