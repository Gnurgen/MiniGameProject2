using UnityEngine;
using System.Collections;

public class OneShotAnis : MonoBehaviour {

    [SerializeField]
    private Transform _startPos, _endPos;
    private float _idleSpeed, _chaseSpeed;
    private NavMeshAgent agent;
    private NavMeshController nmc;
    enum state { one, none};
    state curState;

	void Start () {
        nmc = GetComponent<NavMeshController>();
        _idleSpeed = nmc._idleSpeed;
        _chaseSpeed = nmc._chaseSpeed;
        enabled = false;
	}
    void Update()
    {
        switch (curState)
        {
            case state.one:
                if (Vector3.Distance(transform.position, _endPos.position) < 1.2f)
                {
                    curState = state.none;
                    _despawn();
                }
                    break;
            case state.none:
                break;
        }
    }
	
    public void playOneShot()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.Warp(_startPos.position);
        curState = state.one;
        GameManager.instance.EnemyAggro(); //HÅBER JEG
        agent.speed = _chaseSpeed;
        agent.destination = _endPos.position;
    }

    private void _despawn()
    {
        GameManager.instance.player.GetComponent<ActivateDome>().spawnDomes = true;
        GameManager.instance.player.GetComponent<PlayerControls>().canSprint = true;
        curState = state.none;
        nmc.enabled = true;
        enabled = false;
    }
}
