using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Net;

public class StartmenuInteraction : MonoBehaviour {

    private AudioSource _AS;
    private Sprite _earImgL, _earImgR;
    private GameObject _earFB, _instrucPopUp, _debugPopUp;

    void Start()
    {
        //        _instrucPopUp = GameObject.Find("InstructionsPop-Up");
        //        _instrucPopUp.SetActive(false);
        _earFB = GameObject.Find("EarFeedback");
        _earFB.SetActive(false);
        _debugPopUp = GameObject.Find("DebugPop-Up");
        _debugPopUp.SetActive(false);
        _earImgL = Resources.Load<Sprite>("StartMenu/leftEar");
        _earImgR = Resources.Load<Sprite>("StartMenu/rightEar");
        _AS = GetComponent<AudioSource>();
        _AS.clip = Resources.Load<AudioClip>("StartMenu/leftRightAudio");
        print("NOTE: Left/Right audio and Left/Right images are dummies - REPLACE WITH REAL OBJECTS IN RESOURCES FOLDER");
    }

    public void StartGameButton()
    {
        GameManager.instance.StartGame();
    }

    public void InstructionsButton()
    {
        _instrucPopUp.SetActive(true);
    }

    public void DebugButton()
    {
        _debugPopUp.SetActive(true);
    }

    public void CloseDebugScreen()
    {
        _debugPopUp.SetActive(false);
    }

    public void CloseInstructionScreen()
    {
        _instrucPopUp.SetActive(false);
    }

    public void ToggleMonsterDeath()
    {
        bool b = GameObject.Find("Toggle_Monster").GetComponent<Toggle>().isOn;
        Debug.Log(b);
        //        GameManager.instance.debugManager.monsterDeathImmune = b;
    }

    public void ToggleMusicBoxDeath()
    {
        bool b = GameObject.Find("Toggle_MusicBox").GetComponent<Toggle>().isOn;
        Debug.Log(b);
        //        GameManager.instance.debugManager.musicBoxDeathImmune = b;
    }

    public void ToggleBoundryRings()
    {
        bool b = GameObject.Find("Toggle_DomeRings").GetComponent<Toggle>().isOn;
        Debug.Log(b);
        //        GameManager.instance.debugManager.boundryRings = b;
    }

    public void SoundTestButton()
    {
        StartCoroutine(stereoTest());
    }

    private IEnumerator stereoTest()
    {
        _earFB.SetActive(true);
        _AS.panStereo = -1; //Play to left ear
        _earFB.GetComponent<Image>().sprite = _earImgL;
        _AS.Play();
        yield return new WaitForSeconds(_AS.clip.length+0.1f);
        _AS.panStereo = 1; //Play to right ear
        _earFB.GetComponent<Image>().sprite = _earImgR;
        _AS.Play();
        Invoke("turnImgOff", _AS.clip.length + 0.1f);
    }


    void turnImgOff()
    {
        _earFB.SetActive(false);
    }
}
