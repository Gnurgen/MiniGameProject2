using UnityEngine;
using System.Collections;

public class MusicBox : MonoBehaviour {

    private int currentSpawn = 0;
    public GameObject ParticlePuff;

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
        GameObject particlePuff = (GameObject)Instantiate(ParticlePuff, transform.GetChild(0).GetChild(0).GetChild(0).position + transform.GetChild(0).GetChild(0).localPosition - transform.GetChild(0).GetChild(0).GetChild(0).localPosition, transform.rotation);
        Destroy(particlePuff, 2f);
        MusicBoxSpawn spawnPoint = MusicBoxSpawn.GetNext();
        MusicBoxSpawn.SetCurrent(spawnPoint);
        moveTo(spawnPoint);
    }
}
