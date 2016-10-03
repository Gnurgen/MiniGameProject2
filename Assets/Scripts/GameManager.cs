using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager {

    private static int START_SCENE = 0;
    private static int GAME_SCENE = 1;

    private static GameManager _instance;

    private GameObject _player;
    private GameObject _enemy;
    private GameObject _musicBox;
    private AudioManager _audioManager;
    private int _musicBoxCount = 0;

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
        _instance = null;
        SceneManager.LoadScene(START_SCENE);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(GAME_SCENE);
    }

    public void PlayDeathScene_MusicBox()
    {
    }

    public void PlayDeathScene_Monster()
    {
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


    public delegate void EnemyAggroAction();
    public event EnemyAggroAction OnEnemyAggro;
    public void EnemyAggro()
    {
        OnEnemyAggro();
    }


    public delegate void HitAction(int value);
    public event HitAction OnEnemyAttackHit;
    public void EnemyAttackHit(int i)
    {
        OnEnemyAttackHit(i);
    }

    public delegate void FreezeAction(float value);
    public event FreezeAction OnPlayerFreeze;
    public event FreezeAction OnPlayerUnfreeze;
    public void PlayerFreeze(float i)
    {
        OnPlayerFreeze(i);
    }
    public void PlayerUnfreeze(float i)
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

    //added Stamina value for Fatigue
    public delegate void SprintFatigue(int value);
    public event SprintFatigue OnPlayerFatigue;
    public void PlayerSprintStart()
    {
        OnPlayerSprintStart();
    }
    public void PlayerSprintStop()
    {
        OnPlayerSprintStop();
    }
    public void PlayerFatigue(int i)
    {
        OnPlayerFatigue(i);
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
        OnMusicBoxPlay();
    }
    public void MusicBoxMove()
    {
        OnMusicBoxMove();
    }
    public void MusicBoxPause()
    {
        OnMusicBoxPause();
    }
    public void MusicBoxResume()
    {
        OnMusicBoxResume();
    }
    public void MusicBoxRewindStart()
    {
        OnMusicBoxRewindStart();
    }
    public void MusicBoxRewindStop()
    {
        OnMusicBoxRewindStop();
    }
    public void MusicBoxRewindComplete()
    {
        _musicBoxCount++;
        OnMusicBoxRewindComplete();
    }
    public delegate void Graveyard();
    public event Graveyard OnGateOpen;
    public event Graveyard OnKnockOnCoffin;
    public event Graveyard OnGateCreak;
    public void GateOpen()
    {
        OnGateOpen();
    }
    public void KnockOnCoffin()
    {
        OnKnockOnCoffin();
    }
    public void GateCreak()
    {
        OnGateOpen();
    }
    public delegate void MenuButtons();
    public event MenuButtons StartButton;
    public void OnStartButton()
    {
        StartButton();
    }


}
