using UnityEngine;
using System.Collections;

public class MusicBox : MonoBehaviour {

	void Start () {
	}
	
	void Update () {
	
	}

    public void MoveTo(MusicBoxSpawn spawnPoint)
    {
        transform.position = spawnPoint.transform.position;
    }
}
