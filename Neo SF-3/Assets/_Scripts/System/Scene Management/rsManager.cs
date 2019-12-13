using UnityEngine;
using UnityEngine.SceneManagement;

public class rsManager : MonoBehaviour
{

    private GameObject playersGameObject;
    private SceneTransitionManager playersSceneManager;

    // assigns components
    public void assignComponents(GameObject playersGO, SceneTransitionManager playersSM)
    {
        playersGameObject = playersGO;
        playersSceneManager = playersSM;
    }

    public void loadScene(int id)
    {
        SceneManager.LoadScene(id);
        Destroy(playersGameObject);
    }
}
