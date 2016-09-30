﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager {

    private static string START_SCENE = "StartScene";
    private static string GAME_SCENE = "Game";
    private static string WIN_SCENE = "WinScene";
    private static string LOSE_SCENE_TIME = "LoseTimeScene";
    private static string LOSE_SCENE_DEATH = "LoseDeathScene";

    private static GameManager _instance;
    private static int _musicBoxCount;

    public readonly DebugManager debug = new DebugManager();

    private GameObject _player;
    private GameObject _enemy;
    private GameObject _musicBox;
    private AudioManager _audioManager;

    public static GameManager instance
    {
        get
        {
            if (_instance == null)
                _instance = new GameManager();
            return _instance;
        }
    }

    public GameObject player
    {
        get
        {
            if (_player == null)
                _player = GameObject.FindWithTag("Player");
            return _player;
        }
    }

    public GameObject enemy
    {
        get
        {
            if (_enemy == null)
                _enemy = GameObject.Find("Enemy");
            return _enemy;
        }
    }

    public GameObject musicBox
    {

        get
        {
            if (_musicBox == null)
            {
                _musicBox = GameObject.FindWithTag("MusicBox");
            }
            return _musicBox;
        }
    }

    public AudioManager audioManager
    {
        get
        {
            if (_audioManager == null)
                _audioManager = Object.FindObjectOfType(typeof(AudioManager)) as AudioManager;
            return _audioManager;
        }
    }

    public int musicBoxCount
    {
        get
        {
            return _musicBoxCount;
        }
    }

    public void LeaveGame()
    {
        SceneManager.LoadScene(START_SCENE);
    }

    public void StartGame()
    {
        _musicBoxCount = 0;
        _instance = null;
        SceneManager.LoadScene(GAME_SCENE);
    }

    public void PlayDeathScene_MusicBox()
    {
        if (!debug.musicBoxDeathImmune)
            SceneManager.LoadScene(LOSE_SCENE_TIME);
    }

    public void PlayDeathScene_Monster()
    {
        if (!debug.monsterDeathImmune)
            SceneManager.LoadScene(LOSE_SCENE_DEATH);
    }
    public void PlayWinScene()
    {
        SceneManager.LoadScene(WIN_SCENE);
    }

    public delegate void SpawnAction();
    public event SpawnAction OnEnemySpawn;
    public event SpawnAction OnEnemyDespawn;
    public void EnemySpawn()
    {
        if (OnEnemySpawn != null)
            OnEnemySpawn();
    }
    public void EnemyDespawn()
    {
        if (OnEnemyDespawn != null)
            OnEnemyDespawn();
    }

    public delegate void StepAction();
    public event StepAction OnEnemyStep;
    public event StepAction OnPlayerIdle;
    public void EnemyStep()
    {
        if (OnEnemyStep != null)
            OnEnemyStep();
    }
    public void PlayerIdle()
    {
        if (OnPlayerIdle != null)
            OnPlayerIdle();
    }

    public delegate void AttackAction();
    public event AttackAction OnEnemyAttack;
    public void EnemyAttack()
    {
        if (OnEnemyAttack != null)
            OnEnemyAttack();
    }

    public delegate void EnemyAggroAction();
    public event EnemyAggroAction OnEnemyAggro;
    public void EnemyAggro()
    {
        if (OnEnemyAggro != null)
            OnEnemyAggro();
    }
    public delegate void EnemyIdleAction();
    public event EnemyIdleAction OnEnemyIdle;
    public void EnemyIdle()
    {
        if (OnEnemyIdle != null)
            OnEnemyIdle();
    }
    public delegate void HitAction(int value);
    public event HitAction OnEnemyAttackHit;
    public void EnemyAttackHit(int i)
    {
        if (OnEnemyAttackHit != null)
            OnEnemyAttackHit(i);
    }

    public delegate void FreezeAction(float value);
    public event FreezeAction OnPlayerFreeze;
    public event FreezeAction OnPlayerUnfreeze;
    public void PlayerFreeze(float i)
    {
        if (OnPlayerFreeze != null)
            OnPlayerFreeze(i);
    }
    public void PlayerUnfreeze(float i)
    {
        if (OnPlayerUnfreeze != null)
            OnPlayerUnfreeze(i);
    }

    public delegate void HealthAction(int value);
    public event HealthAction OnPlayerTakeDamage;
    public event HealthAction OnPlayerRecover;
    public void PlayerTakeDamage(int i)
    {
        if (OnPlayerTakeDamage != null)
            OnPlayerTakeDamage(i);
    }
    public void PlayerRecover(int i)
    {
        if (OnPlayerRecover != null)
            OnPlayerRecover(i);
    }

    public delegate void SprintAction();
    public event SprintAction OnPlayerSprint;
    public event SprintAction OnPlayerWalk;
    public event SprintAction OnPlayerFatigue;
    public void PlayerSprint()
    {
        if (OnPlayerSprint != null)
            OnPlayerSprint();
    }
    public void PlayerWalk()
    {
        if (OnPlayerWalk != null)
            OnPlayerWalk();
    }
    public void PlayerFatigue()
    {
        if (OnPlayerFatigue != null)
            OnPlayerFatigue();
    }

    public delegate void MusicBoxAction();
    public event MusicBoxAction OnMusicBoxPlay;
    public event MusicBoxAction OnMusicBoxMove;
    public event MusicBoxAction OnMusicBoxPause;
    public event MusicBoxAction OnMusicBoxResume;
    public event MusicBoxAction OnMusicBoxRewindStart;
    public event MusicBoxAction OnMusicBoxRewindStop;
    public event MusicBoxAction OnMusicBoxRewindComplete;
    public void MusicBoxPlay()
    {
        if (OnMusicBoxPlay != null)
            OnMusicBoxPlay();
    }
    public void MusicBoxMove()
    {
      
        if (OnMusicBoxMove != null)
            OnMusicBoxMove();
    }
    public void MusicBoxPause()
    {
        if (OnMusicBoxPause != null)
            OnMusicBoxPause();
    }
    public void MusicBoxResume()
    {
        if (OnMusicBoxResume != null)
            OnMusicBoxResume();
    }
    public void MusicBoxRewindStart()
    {
        if (OnMusicBoxRewindStart != null)
            OnMusicBoxRewindStart();
    }
    public void MusicBoxRewindStop()
    {
        if (OnMusicBoxRewindStop != null)
            OnMusicBoxRewindStop();
    }
    public void MusicBoxRewindComplete()
    {
        _musicBoxCount++;
        if (_musicBoxCount >= MusicBoxSpawn.GetCount())
        {
//            PlayWinScene();
        }
        if (OnMusicBoxRewindComplete != null)
            OnMusicBoxRewindComplete();
    }
    public delegate void Graveyard();
    public event Graveyard OnGateOpen;
    public event Graveyard OnKnockOnCoffin;
    public event Graveyard OnGateCreak;
    public void GateOpen()
    {
        if (OnGateOpen != null)
            OnGateOpen();
    }
    public void KnockOnCoffin()
    {
        if (OnKnockOnCoffin != null)
            OnKnockOnCoffin();
    }
    public void GateCreak()
    {
        if (OnGateCreak != null)
            OnGateCreak();
    }
    public delegate void MenuButtons();
    public event MenuButtons OnStartButton;
    public void StartButton()
    {
        if (OnStartButton != null)
            OnStartButton();
    }


}
