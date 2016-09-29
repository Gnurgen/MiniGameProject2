using UnityEngine;
using System.Collections;

public class MusicBox : MonoBehaviour {

    private int currentSpawn = 0;

    void Start () {
        GameManager.instance.MusicBoxPlay();
        GameManager.instance.OnMusicBoxMove += MoveToNextSpawn;
    }

    void Update () {
    }

    void OnTriggerEnter(Collider obj)
    {
        if (obj.tag == GameManager.instance.player.tag)
        {

            GameManager.instance.MusicBoxRewindStart();
        }
    }

    void OnTriggerExit(Collider obj)
    {
        if (obj.tag == GameManager.instance.player.tag)
        {
            GameManager.instance.MusicBoxRewindStop();

        }
    }

    private void moveTo(MusicBoxSpawn spawnPoint)
    {
        transform.position = spawnPoint.transform.position;
    }

    public void MoveToNextSpawn()
    {
        MusicBoxSpawn spawnPoint = MusicBoxSpawn.GetNext();
        MusicBoxSpawn.SetCurrent(spawnPoint);
        moveTo(spawnPoint);
    }
}
