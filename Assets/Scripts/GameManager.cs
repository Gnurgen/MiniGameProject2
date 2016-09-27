using UnityEngine;
using System.Collections;

public class GameManager {

    private static GameManager _instance;

    private GameObject _player;
    private GameObject _enemy;
    private GameObject _musicBox;

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
                _enemy = GameObject.FindWithTag("Enemy");
            return _enemy;
        }
    }

    public GameObject musicBox
    {
        get
        {
            if (_musicBox == null)
                _musicBox = GameObject.FindWithTag("MusicBox");
            return _musicBox;
        }
    }

    public delegate void EnemyAttackAction();
    public event EnemyAttackAction OnEnemyAttack; 
    public void EnemyAttack()
    {
        OnEnemyAttack();
    }

    public delegate void MusicBoxPlayAction();
    public event MusicBoxPlayAction OnMusicBoxPlay;
    public void MusicBoxPlay()
    {
        OnMusicBoxPlay();
    }

}
