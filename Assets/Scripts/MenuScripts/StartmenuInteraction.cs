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
        _earFB = GameObject.Find("EarFeedback");
        _earFB.SetActive(false);
        _debugPopUp = GameObject.Find("DebugPop-Up");
        _AS = GetComponent<AudioSource>();
        _AS.clip = Resources.Load<AudioClip>("StartMenu/leftRightAudio");
        print("NOTE: Left/Right audio and Left/Right images are dummies - REPLACE WITH REAL OBJECTS IN RESOURCES FOLDER");

        GameObject.Find("Toggle_Monster").GetComponent<Toggle>().isOn = GameManager.debug.monsterDeathImmune;
        GameObject.Find("Toggle_MusicBox").GetComponent<Toggle>().isOn = GameManager.debug.musicBoxDeathImmune;
        GameObject.Find("Toggle_Joystick").GetComponent<Toggle>().isOn = GameManager.debug.usingJoystick;

        if (GameManager.language == GameManager.Language.English)
        {
            displayEnglishText();
            _earImgL = Resources.Load<Sprite>("StartMenu/leftEarEnglish");
            _earImgR = Resources.Load<Sprite>("StartMenu/rightEarEnglish");
        }
        else
        {
            _earImgL = Resources.Load<Sprite>("StartMenu/leftEar");
            _earImgR = Resources.Load<Sprite>("StartMenu/rightEar");
        }
        _debugPopUp.SetActive(false);
    }

    private void displayEnglishText() {
        GameObject.Find("StartscreenTest").GetComponent<Text>().text = "The tablet is your window out\nSo hold it up in front of your snout";
        GameObject.Find("HowToPlay").GetComponent<Text>().text = "The goal of the game is to find music boxes and wind them up\n\nWalk by holding one finger on the screen.\n\nRun by holding to fingers on the screen.\n\nStand close and look at a music box to wind it up.\n\nWarning! A monster is guarding the music boxes.";
        GameObject.Find("SoundProofSub").GetComponent<Text>().text = "Cannot die to time";
        GameObject.Find("MonsterProofSub").GetComponent<Text>().text = "Cannot die from monsters";
        GameObject.Find("SoundTest").GetComponent<Image>().sprite = Resources.Load<Sprite>("StartMenu/soundTest");
    }

    public void StartGameButton()
    {
    GameManager.instance.InBetweenScreen();
    }

    public void InstructionsButton()
    {
        _instrucPopUp.SetActive(true);
    }

    public void DebugButton()
    {
        _debugPopUp.SetActive(true);
    }

    public void ExitGameButton()
    {
        Application.Quit();
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
        GameManager.debug.monsterDeathImmune = b;
    }

    public void ToggleMusicBoxDeath()
    {
        bool b = GameObject.Find("Toggle_MusicBox").GetComponent<Toggle>().isOn;
        GameManager.debug.musicBoxDeathImmune = b;
    }

    public void ToggleBoundryRings()
    {
        bool b = GameObject.Find("Toggle_DomeRings").GetComponent<Toggle>().isOn;
        GameManager.debug.boundryRings = b;
    }

    public void ToggleJoystick()
    {
        bool b = GameObject.Find("Toggle_Joystick").GetComponent<Toggle>().isOn;
        Debug.Log(b);
        GameManager.debug.usingJoystick = b;
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
