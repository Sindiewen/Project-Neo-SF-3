using UnityEngine;

public class MainMenu : MonoBehaviour
{
    // Variables
    #region Variables

    // Public VAriables
    // ---------------------------------
    public GameObject mainMenuUI;
    public GameObject playerUI;

    // private variables
    // ---------------------------------
    // Component references
    private SceneTransitionManager sceneManager;
    private WorldMusicManager musicManager;

    private bool isPaused = true;


    #endregion

    #region private methods


    private void Start()
    {
        // get components
        sceneManager = GetComponent<SceneTransitionManager>();
        musicManager = GetComponent<WorldMusicManager>();
    }


    #endregion


    //Public methods
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

        // Play curLevelMusic
        musicManager.playMusic(sceneManager.curSceneName);
    }


    #endregion


    // Getters setters
    #region getters/setters


    public bool IsPaused
    {
        get { return isPaused; }
    }

    #endregion
}
