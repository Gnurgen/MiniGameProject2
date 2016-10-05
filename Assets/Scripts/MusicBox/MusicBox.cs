using UnityEngine;
using System.Collections;

public class MusicBox : MonoBehaviour {

    private int currentSpawn = 0;
    public GameObject ParticlePuff;
    private float timeToDie = 0;
    private bool Count = true;
    private bool FinalBox = false;
    
    void Start () {

        GameManager.instance.audioManager.MusicBoxStart();
        //GameManager.instance.audioManager.AmbienceStart(); DEN KOMMER FRA MENU SCENEN NU
        GameManager.instance.audioManager.FootStepStart();
        GameManager.instance.audioManager.BreathStart();
        GameManager.instance.OnMusicBoxMove += MoveToNextSpawn;
        GameManager.instance.OnMusicBoxLast += LastMusicBox;
    }

    void LastMusicBox()
    {
        FinalBox = true;
        
    }
    void Update () {
        if (!FinalBox)
        {
            if (Count)
                timeToDie += 1 * Time.deltaTime;
            if (timeToDie >= 90)
                GameManager.instance.PlayDeathScene_MusicBox();
        }
    }
   
    void OnTriggerEnter(Collider obj)
    {
        if (!FinalBox)
        {
            if (obj.tag == GameManager.instance.player.tag)
            {
                Count = false;

                GameManager.instance.MusicBoxPause();
                GameManager.instance.MusicBoxRewindStart();
            }
        }
    }
    
    void OnTriggerExit(Collider obj)
    {
        if (!FinalBox)
        {
            if (obj.tag == GameManager.instance.player.tag)
            {
                Count = true;
                GameManager.instance.MusicBoxResume();
                GameManager.instance.MusicBoxRewindStop();

            }
        }
    }

    private void moveTo(MusicBoxSpawn spawnPoint)
    {
        if (!FinalBox)
        {

            transform.position = spawnPoint.transform.position;
            timeToDie = 0;
            Count = true;
        }
    }

    public void MoveToNextSpawn()
    {
        if (!FinalBox)
        {
            GameObject particlePuff = (GameObject)Instantiate(ParticlePuff, transform.GetChild(0).GetChild(0).GetChild(0).position, transform.rotation);

            //GameObject particlePuff = (GameObject)Instantiate(ParticlePuff, transform.GetChild(0).GetChild(0).GetChild(0).position + transform.GetChild(0).GetChild(0).localPosition - transform.GetChild(0).GetChild(0).GetChild(0).localPosition, transform.rotation);
            Destroy(particlePuff, 2f);
            MusicBoxSpawn spawnPoint = MusicBoxSpawn.GetNext();
            MusicBoxSpawn.SetCurrent(spawnPoint);
            moveTo(spawnPoint);
        }
    }
}
