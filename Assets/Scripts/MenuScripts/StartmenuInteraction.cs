using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Net;

public class StartmenuInteraction : MonoBehaviour {

    private AudioSource AS;
    public Sprite earImgL, earImgR;
   public GameObject earFB;

    void Start()
    {
        earFB = GameObject.Find("EarFeedback");
        earFB.SetActive(false);
        earImgL = Resources.Load<Sprite>("StartMenu/leftEar");
        earImgR = Resources.Load<Sprite>("StartMenu/rightEar");
        AS = GetComponent<AudioSource>();
        AS.clip = Resources.Load<AudioClip>("StartMenu/leftRightAudio");
        print("NOTE: Left/Right audio and Left/Right images are dummies - REPLACE WITH REAL OBJECTS IN RESOURCES FOLDER");
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

    void Update()
    {

    }

    private IEnumerator stereoTest()
    {
        earFB.SetActive(true);
        AS.panStereo = -1; //Play to left ear
        earFB.GetComponent<Image>().sprite = earImgL;
        AS.Play();
        yield return new WaitForSeconds(AS.clip.length+0.1f);
        AS.panStereo = 1; //Play to right ear
        earFB.GetComponent<Image>().sprite = earImgR;
        AS.Play();
        Invoke("turnImgOff", AS.clip.length + 0.1f);
    }


    void turnImgOff()
    {
        earFB.SetActive(false);
    }
}
