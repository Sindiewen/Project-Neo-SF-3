using UnityEngine;

public class fadeScemeTransition : MonoBehaviour
{
    public SceneTransitionManager sceneTransitionManager;

    public void inititateLevelLoad()
    {
        sceneTransitionManager.transitionScene();
    }
    public void initLoadCheckers()
    {
        sceneTransitionManager.load();
    }
}
