using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour{

    [Header("Music Box")]
    [SerializeField]
    private string MusicBoxPlay;
          [SerializeField]
    private string MusicBoxStop,
        MusicBoxPause,
        MusicBoxResume, 
        MusicBoxRewindPlay, 
        MusicBoxRewindStop, 
        MusicBoxPuff,
        MusicBoxStateGroup;

    [Header("Player")]
    [SerializeField]
    private string PlayerFootPrint;
    [SerializeField]
    private string PlayerStamina,
        Running,
        Walking,
        IcingScreenPlay,
        IcingScreenStop;

    [Header("Monster")]
    [SerializeField]
    private string MonsterFootPrint;
    [SerializeField]
    private string MonsterAttack,
        MonsterWarning;
   
    [Header("Ambience")]
    [SerializeField]
    private string Ambience;
    [SerializeField]
    private string Grave,
        PlayGround,
        Lake;

    void OnEnemyAttack()
    {

    }

    // Music Box Events
    void MB_Play()
    {
        AkSoundEngine.PostEvent(MusicBoxPlay, GameManager.instance.musicBox);
        AkSoundEngine.RenderAudio();
    }
    void MB_Stop()
    {
        AkSoundEngine.PostEvent(MusicBoxStop, GameManager.instance.musicBox);
        AkSoundEngine.RenderAudio();
    }
    void MB_Pause()
    {
        AkSoundEngine.PostEvent(MusicBoxPause, GameManager.instance.musicBox);
        AkSoundEngine.RenderAudio();
    }
    void MB_Resume()
    {
        AkSoundEngine.PostEvent(MusicBoxResume, GameManager.instance.musicBox);
        AkSoundEngine.RenderAudio();
    }
    void MB_Rewind_Play()
    {
        AkSoundEngine.PostEvent(MusicBoxRewindPlay, GameManager.instance.musicBox);
        AkSoundEngine.RenderAudio();
    }
    void MB_Rewind_Stop()
    {
        AkSoundEngine.PostEvent(MusicBoxRewindStop, GameManager.instance.musicBox);
        AkSoundEngine.RenderAudio();
    }
    void MB_Puff()
    {
        AkSoundEngine.PostEvent(MusicBoxPuff, GameManager.instance.musicBox);
        AkSoundEngine.RenderAudio();
    }
    void MB_State()
    {
        //AkSoundEngine.SetState(MusicBoxStateGroup, GameManager.instance.musicBoxCount);

    }


    void Start ()
    {
        /*
        if (GameManager.instance.audioManager == null)
            GameManager.instance.audioManager = this;
        else
            Destroy();
        GameManager.instance.OnEnemyAttack += OnEnemyAttack;
        GameManager.instance.OnMusicBoxPlay += MB_Play;
        GameManager.instance.OnMusicBoxStop += MB_Stop;
        GameManager.instance.OnMusicBoxPause += MB_Pause;
        GameManager.instance.OnMusicBoxResume += MB_Resume;
        GameManager.instance.OnMusicBoxRewindPlay += MB_Rewind_Play;
        GameManager.instance.OnMusicBoxRewindStop += MB_Rewind_Stop;
        GameManager.instance.OnMusicBoxPuff += MB_Puff;
        GameManager.instance.OnMusicBoxState += MB_State;
        GameManager.instance.OnPlayerFootprint += PlayerFootPrint;
        GameManager.instance.OnPlayerRunning += PlayerRunning;
        GameManager.instance.OnPlayerWalking += PlayerWalking;
        GameManager.instance.OnIcingScreenStart += IcingScreenStart;
        GameManager.instance.OnIcingScreenStop += IcingScreenStop;s
         
         
         
         PlayerFootPrint;
    [SerializeField]
    private string PlayerStamina,
        Running,
        Walking,
        IcingScreenPlay,
        IcingScreenStop;

         
         
         
         */
    }

    // Update is called once per frame
    void Update () {
	
	}
}
