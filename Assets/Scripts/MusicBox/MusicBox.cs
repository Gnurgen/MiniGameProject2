using UnityEngine;
using System.Collections;

public class MusicBox : MonoBehaviour {

    public GameObject[] musicSpawns = new GameObject[5];

    private int currentSpawn = 0;
    public GameObject ParticlePuff;
    void Start () {
        GameManager.instance.MusicBoxPlay();
        //GameManager.instance.OnMusicBoxMove += MoveToNext;
        GameManager.instance.OnMusicBoxMove += MoveToNextSpawn;

        transform.position = musicSpawns[0].transform.position;
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

    public void MoveTo(MusicBoxSpawn spawnPoint)
    {
        transform.position = spawnPoint.transform.position;
    }

    public void MoveToNext()
    {
        MoveTo(MusicBoxSpawn.GetNext());
    }

    public void MoveToNextSpawn()
    {
        GameObject particlePuff = (GameObject)Instantiate(ParticlePuff, transform.GetChild(0).GetChild(0).GetChild(0).position + transform.GetChild(0).GetChild(0).localPosition - transform.GetChild(0).GetChild(0).GetChild(0).localPosition, transform.rotation);
        Destroy(particlePuff, 2f);

        currentSpawn++;
        transform.position = musicSpawns[currentSpawn].transform.position;
    }
}
