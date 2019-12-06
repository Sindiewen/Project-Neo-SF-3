using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneTransitionManager : MonoBehaviour
{

    // Variables
    // --------------------------------
    #region Variables
    // Public Variables
    

    [Header("Scene Manager")]
    public Animator fadeAnim;
    public PlayerInputManager[] players;

    // Priavate variables
    private TransitionSetter nextScene;
    private string nextScenToTransition;
    private bool levelSet = false;
    private GameObject TransitionCheckerGO;
    [SerializeField] private SceneTransitionChecker[] transitionChecker;

    public float WaitForSeconds { get; private set; }


    #endregion


    #region private Methods

    private void Start()
    {
        players = transform.GetComponentsInChildren<PlayerInputManager>(); 
        //getTransitionCheckers();
    }   

    private void getTransitionCheckers()
    {
        TransitionCheckerGO = GameObject.FindGameObjectWithTag("SceneTransitionHolder");
        transitionChecker = TransitionCheckerGO.GetComponentsInChildren<SceneTransitionChecker>();
    }

    /// <summary>
    /// Unity update method
    /// 
    /// Runs once every frame
    /// </summary>
    private void Update()
    {
        if (!levelSet)
        {
            for (int i = 0; i < transitionChecker.Length; i++)
            {
                nextScene = transitionChecker[i].hasHitPlayer();
                // If player has been hit, change level
                if (transitionChecker[i].hasHitPlayer() != null)
                {
                    // Initiate level change
                    levelSet = true;
                    nextScenToTransition = nextScene.nextScene;
                    initLevelChange();
                }
            }
        }
        
        
    }



    /// Level change
    /// // --------------------------

    private void initLevelChange()
    {
        /*
         * Initiate fade to black anim
         * fade to black anim ends, triggers load scene
         * loads scene
         */
        fadeAnim.SetTrigger("SwitchScene");
    }

    #endregion


    #region public Methods

    /// <summary>
    /// WHen called, it transitions to the next scene stated in the nextScenToLoad
    /// </summary>
    public void transitionScene()
    {
        levelSet = false;
        for (int i = 0; i < players.Length; ++i)
        {
            players[i].transform.position = nextScene.location + new Vector2(i * 2, 0);
        }
        transitionChecker = new SceneTransitionChecker[0];
        TransitionCheckerGO = null;
        StartCoroutine(transitionAsync());
        
    }

    private IEnumerator transitionAsync()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(nextScenToTransition);
        operation.allowSceneActivation = false;
        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            if (progress >= 1.0f)
            {
                operation.allowSceneActivation = true;
                fadeAnim.SetTrigger("IntoGame");
            }
            yield return null;
        }
    }

    public void load()
    {
        getTransitionCheckers();
    }

    #endregion

}

