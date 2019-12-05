using UnityEngine;

public class PlayersManager : MonoBehaviour
{
    // Variables
    public GameObject[] players;    // gameobjects storing the players
        
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
