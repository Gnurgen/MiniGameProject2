using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Net;

public class StartmenuInteraction : MonoBehaviour {

    AudioSource AS;

    void Start()
    {
        AS = GetComponent<AudioSource>();
    }

    public void StartGameButton()
    {
        //gamehandler.startgame
    }

    public void InfoScreenButton()
    {

    }

    public void SoundTestButton()
    {
        StartCoroutine(stereoTest());
    }

    void OnGUI()
    {

    }

    private IEnumerator stereoTest()
    {
        AS.panStereo = -1; //Play to left ear
        AS.Play();
        yield return new WaitForSeconds(AS.clip.length+0.1f);
        AS.panStereo = 1; //Play to right ear
        AS.Play();
    }
}
