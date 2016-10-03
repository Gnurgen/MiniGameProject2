using UnityEngine;
using System.Collections;
using System;

public class AudioManager : MonoBehaviour{

    [Header("Music Box")]
    [SerializeField]
    private string _MusicBoxPlay;
          [SerializeField]
    private string _MusicBoxStop,
        _MusicBoxPause,
        _MusicBoxResume, 
        _MusicBoxRewindPlay, 
        _MusicBoxRewindStop, 
        _MusicBoxPuff,
        _MusicBoxStateGroup,
        _MusicBoxSwitchGroup,
        _MusicBoxBrokenSwitch,
        _MusicBoxUnBrokenSwitch;

    [Header("Player")]
    [SerializeField]
    private string _PlayerIdle;
    [SerializeField]
    private string _PlayerSprint,
        _PlayerWalk,
        _PlayerFatigue,
        _PlayerFreeze,
        _PlayerUnfreeze,
        _PlayerTakeDamage,
        _PlayerRecover,
        _PlayerStepStart,
        _PlayerBreath,
        _Stamina_Par;
    [Header("Monster")]
    [SerializeField]
    private string _MonsterStep;
    [SerializeField]
    private string _MonsterAttack,
        _MonsterAttackHit,
 //       _MonsterSpawn,
        _MonsterDespawn,
        _MonsterAggro,
        _MonsterGrowl_Play,
        _MonsterGrowl_Stop;
   
    [Header("Ambience")]
    [SerializeField]
    private string _AmbienceStart;
    [SerializeField]
    private string _AmbienceStop,
        _KnockOnCoffin,
        _GateCreak,
        _GateOpen,
        _Lake;
    [Header("Menu")]
    [SerializeField]
    private string _StartButton;


    // MISC VOIDS FOR GAME MANAGER
    public void FootStepStart()
    {
        AkSoundEngine.PostEvent(_PlayerStepStart, GameManager.instance.player);
        AkSoundEngine.RenderAudio();
    }
    public void AmbienceStart()
    {
        AkSoundEngine.PostEvent(_AmbienceStart, gameObject);
        AkSoundEngine.RenderAudio();
    }
    public void AmbienceStop()
    {
        AkSoundEngine.PostEvent(_AmbienceStop, gameObject);
        AkSoundEngine.RenderAudio();
    }
    public void MusicBoxStart()
    {
        MB_Play();
    }
    public void BreathStart()
    {
        AkSoundEngine.PostEvent(_PlayerBreath, GameManager.instance.player);
        AkSoundEngine.RenderAudio();
    }
    public void StaminaChange(float stamina)
    {
        print(stamina);
        AkSoundEngine.SetRTPCValue(_Stamina_Par, stamina);
    }



    // Music Box Events
    void MB_Play()
    {
        AkSoundEngine.PostEvent(_MusicBoxPlay, GameManager.instance.musicBox);
        AkSoundEngine.RenderAudio();
    }
    void MB_Stop()
    {
        AkSoundEngine.PostEvent(_MusicBoxStop, GameManager.instance.musicBox);
        AkSoundEngine.RenderAudio();
    }
    void MB_Pause()
    {
        AkSoundEngine.PostEvent(_MusicBoxPause, GameManager.instance.musicBox);
        AkSoundEngine.RenderAudio();
        print(GameManager.instance.musicBox);
    }
    void MB_Resume()
    {
        AkSoundEngine.PostEvent(_MusicBoxResume, GameManager.instance.musicBox);
        AkSoundEngine.RenderAudio();
    }
    void MB_Rewind_Play()
    {
        AkSoundEngine.PostEvent(_MusicBoxRewindPlay, GameManager.instance.musicBox);
        AkSoundEngine.RenderAudio();
    }
    void MB_Rewind_Stop()
    {
        AkSoundEngine.PostEvent(_MusicBoxRewindStop, GameManager.instance.musicBox);
        AkSoundEngine.RenderAudio();
        MB_SwitchUnBroken();
    }
    void MB_State()
    {
        AkSoundEngine.SetState(_MusicBoxStateGroup,GameManager.instance.musicBoxCount.ToString());
    }
    void MB_SwitchBroken()
    {
        AkSoundEngine.SetSwitch(_MusicBoxSwitchGroup,_MusicBoxBrokenSwitch, GameManager.instance.musicBox);
    }
    void MB_SwitchUnBroken()
    {
        AkSoundEngine.SetSwitch(_MusicBoxSwitchGroup, _MusicBoxUnBrokenSwitch, GameManager.instance.musicBox);
    }
    void MB_Move()
    {
        AkSoundEngine.PostEvent(_MusicBoxStop, GameManager.instance.musicBox);
        AkSoundEngine.RenderAudio();
        AkSoundEngine.PostEvent(_MusicBoxPuff, GameManager.instance.musicBox);
        AkSoundEngine.PostEvent(_MusicBoxPlay, GameManager.instance.musicBox);
        AkSoundEngine.RenderAudio();
    }

    //Player Events
    void PlayerIdle()
    {
        AkSoundEngine.PostEvent(_PlayerIdle, GameManager.instance.player);
        AkSoundEngine.RenderAudio();
    }
    void PlayerSprint()
    {
        AkSoundEngine.PostEvent(_PlayerSprint, GameManager.instance.player);
        AkSoundEngine.RenderAudio();
    }
    void PlayerWalk()
    {
        AkSoundEngine.PostEvent(_PlayerWalk, GameManager.instance.player);
        AkSoundEngine.RenderAudio();
    }
    void PlayerFatigue()
    {
        AkSoundEngine.PostEvent(_PlayerFatigue, GameManager.instance.player);
        AkSoundEngine.RenderAudio();
    }
    void PlayerFreeze(float value)
    {
        //value = Vector3.Distance(GameManager.instance.player.transform.position, GameManager.instance.enemy.transform.position);
        AkSoundEngine.PostEvent(_PlayerFreeze, GameManager.instance.player);
        AkSoundEngine.RenderAudio();
    }
    void PlayerUnfreeze(float value)
    {
        //value = Vector3.Distance(GameManager.instance.player.transform.position, GameManager.instance.enemy.transform.position);
        AkSoundEngine.PostEvent(_PlayerUnfreeze, GameManager.instance.player);
        AkSoundEngine.RenderAudio();
    }
    void PlayerTakeDamage(int value)
    {
        AkSoundEngine.PostEvent(_PlayerTakeDamage, GameManager.instance.player);
        AkSoundEngine.RenderAudio();
    }
    void PlayerRecover(int value)
    {
        AkSoundEngine.PostEvent(_PlayerRecover, GameManager.instance.player);
        AkSoundEngine.RenderAudio();
    }

    // Monster Events
    void EnemyAttack()
    {
        AkSoundEngine.PostEvent(_MonsterAttack, GameManager.instance.enemy);
        AkSoundEngine.RenderAudio();
    }
    void EnemyStep()
    {
        AkSoundEngine.PostEvent(_MonsterStep, GameManager.instance.enemy);
        AkSoundEngine.RenderAudio();
    }
    void EnemyAttackHit(int value)
    {
        AkSoundEngine.PostEvent(_MonsterAttackHit, GameManager.instance.enemy);
        AkSoundEngine.RenderAudio();
    }
    
    void EnemyDespawn()
    {
        AkSoundEngine.PostEvent(_MonsterGrowl_Stop, GameManager.instance.enemy);
        AkSoundEngine.PostEvent(_MonsterDespawn, GameManager.instance.enemy);
        AkSoundEngine.RenderAudio();
    }
    void EnemyAggro()
    {
        AkSoundEngine.PostEvent(_MonsterAggro, GameManager.instance.enemy);
        AkSoundEngine.PostEvent(_MonsterGrowl_Play, GameManager.instance.enemy);
        AkSoundEngine.RenderAudio();
    }


    //Ambience Sound
    void Ambience()
    {
        AkSoundEngine.PostEvent(_AmbienceStart, GameManager.instance.enemy);
        AkSoundEngine.RenderAudio();
    }
    void KnockOnCoffin()
    {
        AkSoundEngine.PostEvent(_KnockOnCoffin, GameManager.instance.enemy);
        AkSoundEngine.RenderAudio();
    }
    void GateCreak()
    {
        AkSoundEngine.PostEvent(_GateCreak, GameManager.instance.enemy);
        AkSoundEngine.RenderAudio();
    }
    void GateOpen()
    {
        AkSoundEngine.PostEvent(_GateOpen, GameManager.instance.enemy);
        AkSoundEngine.RenderAudio();
    }
    //Menu Buttons
    void StartButton()
    {
        AkSoundEngine.PostEvent(_StartButton, GameManager.instance.enemy);
        AkSoundEngine.RenderAudio();
    }

    void Start ()
    {

        DontDestroyOnLoad(gameObject);

        /*                   TO BE CONTINUED
         if (GameManager.instance.audioManager == null)
             GameManager.instance.audioManager = this;
         else
             Destroy(this);
        */

        Subscribe2GameManager();
         
    }

    public void Subscribe2GameManager()
    {
        // Music Box Events
        GameManager.instance.OnMusicBoxPlay += MB_Play;
        GameManager.instance.OnMusicBoxRewindComplete += MB_Stop;
        GameManager.instance.OnMusicBoxPause += MB_Pause;
        GameManager.instance.OnMusicBoxResume += MB_Resume;
        GameManager.instance.OnMusicBoxRewindStart += MB_Rewind_Play;
        GameManager.instance.OnMusicBoxRewindStop += MB_Rewind_Stop;
        GameManager.instance.OnMusicBoxMove += MB_Move;

        // Player Events
        GameManager.instance.OnPlayerIdle += PlayerIdle;
        GameManager.instance.OnPlayerSprint += PlayerSprint;
        GameManager.instance.OnPlayerWalk += PlayerWalk;
        GameManager.instance.OnPlayerFatigue += PlayerFatigue;
        GameManager.instance.OnPlayerFreeze += PlayerFreeze;
        GameManager.instance.OnPlayerUnfreeze += PlayerUnfreeze;
        GameManager.instance.OnPlayerTakeDamage += PlayerTakeDamage;
        GameManager.instance.OnPlayerRecover += PlayerRecover;

        // Monster Events
        GameManager.instance.OnEnemyAttack += EnemyAttack;
        GameManager.instance.OnEnemyStep += EnemyStep;
        GameManager.instance.OnEnemyAttackHit += EnemyAttackHit;
        GameManager.instance.OnEnemyDespawn += EnemyDespawn;
        GameManager.instance.OnEnemyAggro += EnemyAggro;
        //Ambience Events
        GameManager.instance.OnKnockOnCoffin += KnockOnCoffin;
        GameManager.instance.OnGateCreak += GateCreak;
        GameManager.instance.OnGateOpen += GateOpen;
        
    }




    // Update is called once per frame
    void Update () {
	
	}
}
