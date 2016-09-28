using UnityEngine;
using System.Collections;

public class MusicBox : MonoBehaviour {

	void Start () {
        GameManager.instance.MusicBoxPlay();
        GameManager.instance.OnMusicBoxMove += MoveToNext;
    }

    void Update () {

    }

    void OnTriggerEnter(Collider obj)
    {
        if (obj == GameManager.instance.player)
        {
            GameManager.instance.MusicBoxRewindStart();
        }
    }

    void OnTriggerExit(Collider obj)
    {
        if (obj == GameManager.instance.player)
        {
            GameManager.instance.MusicBoxRewindStop();
        }
    }

    public void MoveTo(MusicBoxSpawn spawnPoint)
    {
        transform.position = spawnPoint.transform.position;
    }

    public void MoveToNext()
    {
        MoveTo(MusicBoxSpawn.GetNext());
    }
}
