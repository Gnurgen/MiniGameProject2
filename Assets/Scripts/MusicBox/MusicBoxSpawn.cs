using UnityEngine;
using System.Collections;

public class MusicBoxSpawn : MonoBehaviour {

    private static MusicBoxSpawn current;
    public MusicBoxSpawnList spawnList;

    void Start () {
        if (current == null)
        {
            current = spawnList.First().GetComponent<MusicBoxSpawn>();
            GameManager.instance.musicBox.transform.position = current.transform.position;
        }
    }

    void Update () {
	
	}

    public static MusicBoxSpawn GetNext()
    {
        MusicBoxSpawn next = current.spawnList.Next(current.gameObject).GetComponent<MusicBoxSpawn>();
        current = next;
        return next;
    }
}
