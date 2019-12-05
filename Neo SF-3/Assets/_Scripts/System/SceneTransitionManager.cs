using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneTransitionManager : MonoBehaviour
{

    // Variables
    // --------------------------------
    #region Variables
    // Public Variables
    public Rect sceneRect;
    public Vector2 sceneDirection;
    public float sceneDistance;
    public LayerMask collisionMask;

    [Header("Scene Manager")]
    public string nextSceneToLoad;



    #endregion


    #region private Methods
    /// <summary>
    /// Unity update method
    /// 
    /// Runs once every frame
    /// </summary>
    private void Update()
    {
        // If player has been hit, change level
        if (hasHitPlayer())
        {
            // Initiate level change
            initLevelChange();
        }
    }

    /// <summary>
    /// Checks to see if has been hit
    /// </summary>
    /// <returns></returns>
    private bool hasHitPlayer()
    {
        Vector2 rayOrigin = (Vector2)transform.position + sceneRect.center;
        RaycastHit2D hit = Physics2D.BoxCast(rayOrigin, sceneRect.size, 0, sceneDirection, sceneDistance, collisionMask);
        return hit;
    }


    

    /// Level change
    /// // --------------------------

    private void initLevelChange()
    {

    }

    #endregion


    #region public Methods

    #endregion

}
