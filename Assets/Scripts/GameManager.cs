using UnityEngine;
using System.Collections;

public class GameManager {

    private static GameManager _instance;
    public GameObject player;
    public GameObject enemy;
    public GameObject musicBox;

    public static GameManager instance
    {
        get
        {
            if (_instance == null)
                _instance = new GameManager();
            return _instance;
        }
    }
}
