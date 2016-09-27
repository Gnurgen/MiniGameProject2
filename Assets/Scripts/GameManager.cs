using UnityEngine;
using System.Collections;

public class GameManager {

    private static GameManager _instance;

    private GameObject _player;
    private GameObject _enemy;
    private GameObject _musicBox;
    private AudioManager _audioManager;
    public int musicBoxCount = 0;

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
                _musicBox = GameObject.Find("MusicBox");
            return _musicBox;
        }
    }

    public AudioManager audioManager
    {
        get
        {
//            if (_audioManager == null)
//                _audioManager = Object.FindObjectOfType(typeof (AudioManager)) as AudioManager;
            return _audioManager;
        }
    }

    public delegate void SpawnAction();
    public event SpawnAction OnEnemySpawn;
    public event SpawnAction OnEnemyDespawn;
    public void EnemySpawn()
    {
        OnEnemySpawn();
    }
    public void EnemyDespawn()
    {
        OnEnemyDespawn();
    }

    public delegate void StepAction();
    public event StepAction OnEnemyStep;
    public event StepAction OnPlayerStep;
    public void EnemyStep()
    {
        OnEnemyStep();
    }
    public void PlayerStep()
    {
        OnPlayerStep();
    }

    public delegate void AttackAction();
    public event AttackAction OnEnemyAttack;
    public void EnemyAttack()
    {
        OnEnemyAttack();
    }

    public delegate void HitAction(int value);
    public event HitAction OnEnemyAttackHit;
    public void EnemyAttackHit(int i)
    {
        OnEnemyAttackHit(i);
    }

    public delegate void FreezeAction(int value);
    public event FreezeAction OnPlayerFreeze;
    public event FreezeAction OnPlayerUnfreeze;
    public void PlayerFreeze(int i)
    {
        OnPlayerFreeze(i);
    }
    public void PlayerUnfreeze(int i)
    {
        OnPlayerFreeze(i);
    }

    public delegate void HealthAction(int value);
    public event HealthAction OnPlayerTakeDamage;
    public event HealthAction OnPlayerRecover;
    public void PlayerTakeDamage(int i)
    {
        OnPlayerTakeDamage(i);
    }
    public void PlayerRecover(int i)
    {
        OnPlayerRecover(i);
    }

    public delegate void SprintAction();
    public event SprintAction OnPlayerSprintStart;
    public event SprintAction OnPlayerSprintStop;
    public event SprintAction OnPlayerFatigue;
    public void PlayerSprintStart()
    {
        OnPlayerSprintStart();
    }
    public void PlayerSprintStop()
    {
        OnPlayerSprintStop();
    }
    public void PlayerFatigue()
    {
        OnPlayerFatigue();
    }

    public delegate void MusicBoxAction();
    public event MusicBoxAction OnMusicBoxPlay;
    public event MusicBoxAction OnMusicBoxStop;
    public event MusicBoxAction OnMusicBoxPause;
    public event MusicBoxAction OnMusicBoxResume;
    public event MusicBoxAction OnMusicBoxRewindStart;
    public event MusicBoxAction OnMusicBoxRewindStop;
    public event MusicBoxAction OnMusicBoxRewinded;
    public void MusicBoxPlay()
    {
        OnMusicBoxPlay();
    }

}
