using UnityEngine;
using System.Collections;

public class MusicBox : MonoBehaviour {

    private int currentSpawn = 0;
    public GameObject ParticlePuff;
    private float timeToDie = 0;
    private bool Count = true;
    
    void Start () {
//        GameManager.instance.audioManager.MusicBoxStart();
//        GameManager.instance.audioManager.AmbienceStart();
//        GameManager.instance.audioManager.FootStepStart();
//        GameManager.instance.audioManager.BreathStart();
        GameManager.instance.OnMusicBoxMove += MoveToNextSpawn;
    }

    void Update () {
        if(Count)
            timeToDie += 1 * Time.deltaTime;
        if (timeToDie >= 90)
            GameManager.instance.PlayDeathScene_MusicBox();
    }
   
    void OnTriggerEnter(Collider obj)
    {
        if (obj.tag == GameManager.instance.player.tag)
        {
            Count = false;
            GameManager.instance.MusicBoxPause();
            GameManager.instance.MusicBoxRewindStart();
        }
    }
    
    void OnTriggerExit(Collider obj)
    {
        if (obj.tag == GameManager.instance.player.tag)
        {
            Count = true;
            GameManager.instance.MusicBoxResume();
            GameManager.instance.MusicBoxRewindStop();

        }
    }

    private void moveTo(MusicBoxSpawn spawnPoint)
    {
        transform.position = spawnPoint.transform.position;
        timeToDie = 0;
        Count = true;
        
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
