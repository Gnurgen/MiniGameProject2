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
        _MusicBoxStateGroup;

    [Header("Player")]
    [SerializeField]
    private string _PlayerStep;
    [SerializeField]
    private string _PlayerSprintStart,
        _PlayerSprintStop,
        _PlayerFatigue,
        _PlayerFreeze,
        _PlayerUnfreeze,
        _PlayerTakeDamage,
        _PlayerRecover;

    [Header("Monster")]
    [SerializeField]
    private string _MonsterStep;
    [SerializeField]
    private string _MonsterAttack,
        _MonsterAttackHit,
        _MonsterSpawn,
        _MonsterDespawn,
        _MonsterAggro;
   
    [Header("Ambience")]
    [SerializeField]
    private string _Ambience;
    [SerializeField]
    private string _KnockOnCoffin,
        _GateCreak,
        _GateOpen,
        _Lake;
    [Header("Menu")]
    [SerializeField]
    private string _StartButton;

    // Music Box Events
    void MB_Play()
    {
        AkSoundEngine.PostEvent(_MusicBoxPlay, GameManager.instance.musicBox);
        AkSoundEngine.RenderAudio();
    }
    void MB_Stop()
    {
        AkSoundEngine.PostEvent(_MusicBoxStop, GameManager.instance.musicBox);
        MB_State();
        AkSoundEngine.PostEvent(_MusicBoxPuff, GameManager.instance.musicBox);
        AkSoundEngine.PostEvent(_MusicBoxPlay, GameManager.instance.musicBox);
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
    }
    void MB_State()
    {
       AkSoundEngine.SetState(_MusicBoxStateGroup,GameManager.instance.musicBoxCount.ToString());

    }
    void MB_Move()
    {
        AkSoundEngine.PostEvent(_MusicBoxPuff, GameManager.instance.musicBox);
        AkSoundEngine.RenderAudio();
    }

    //Player Events
    void PlayerStep()
    {
        AkSoundEngine.PostEvent(_PlayerStep, GameManager.instance.player);
        AkSoundEngine.RenderAudio();
    }
    void PlayerSprintStart()
    {
        AkSoundEngine.PostEvent(_PlayerSprintStart, GameManager.instance.player);
        AkSoundEngine.RenderAudio();
    }
    void PlayerSprintStop()
    {
        AkSoundEngine.PostEvent(_PlayerSprintStop, GameManager.instance.player);
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
    void EnemySpawn()
    {
        AkSoundEngine.PostEvent(_MonsterSpawn, GameManager.instance.enemy);
        AkSoundEngine.RenderAudio();
    }
    void EnemyDespawn()
    {
        AkSoundEngine.PostEvent(_MonsterDespawn, GameManager.instance.enemy);
        AkSoundEngine.RenderAudio();
    }
    void EnemyAggro()
    {
        AkSoundEngine.PostEvent(_MonsterAggro, GameManager.instance.enemy);
        AkSoundEngine.RenderAudio();
    }


    //Ambience Sound
    void Ambience()
    {
        AkSoundEngine.PostEvent(_Ambience, GameManager.instance.enemy);
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
       /*                   TO BE CONTINUED
        if (GameManager.instance.audioManager == null)
            GameManager.instance.audioManager = this;
        else
            Destroy(this);
       */


        // Music Box Events
        GameManager.instance.OnMusicBoxPlay += MB_Play;
        GameManager.instance.OnMusicBoxRewindComplete += MB_Stop;
        GameManager.instance.OnMusicBoxPause += MB_Pause;
        GameManager.instance.OnMusicBoxResume += MB_Resume;
        GameManager.instance.OnMusicBoxRewindStart += MB_Rewind_Play;
        GameManager.instance.OnMusicBoxRewindStop += MB_Rewind_Stop;
        GameManager.instance.OnMusicBoxMove += MB_Move;

        // Player Events
        GameManager.instance.OnPlayerStep += PlayerStep;
        GameManager.instance.OnPlayerSprintStart += PlayerSprintStart;
        GameManager.instance.OnPlayerSprintStop += PlayerSprintStop;
        GameManager.instance.OnPlayerFatigue += PlayerFatigue;
        GameManager.instance.OnPlayerFreeze += PlayerFreeze;
        GameManager.instance.OnPlayerUnfreeze += PlayerUnfreeze;
        GameManager.instance.OnPlayerTakeDamage += PlayerTakeDamage;
        GameManager.instance.OnPlayerRecover += PlayerRecover;
        
        // Monster Events
        GameManager.instance.OnEnemyAttack += EnemyAttack;
        GameManager.instance.OnEnemyStep += EnemyStep;
        GameManager.instance.OnEnemyAttackHit += EnemyAttackHit; 
        GameManager.instance.OnEnemySpawn += EnemySpawn;
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
