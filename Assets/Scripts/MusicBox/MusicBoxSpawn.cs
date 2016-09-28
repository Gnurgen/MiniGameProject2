using UnityEngine;
using System.Collections;

public class MusicBoxSpawn : MonoBehaviour {

    private static MusicBoxSpawn current;
    public MusicBoxSpawnList spawnList;

    void Start () {
        if (current == null)
        {
            current = spawnList.First().GetComponent<MusicBoxSpawn>();
            GameManager.instance.musicBox.MoveTo(current);
        }
    }

    void Update () {
	
	}

    public static getNext()
    {
        _spawnList.Next();
    }
}
