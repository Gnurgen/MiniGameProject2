using UnityEngine;
using System.Collections;

public class OneShotAnis : MonoBehaviour {

    [SerializeField]
    private Transform _startPos, _endPos;
    [SerializeField]
    private float _secAniDist, _secAniChaseTime;
    private float _idleSpeed, _chaseSpeed;
    private NavMeshAgent agent;
    private NavMeshController nmc;
    enum state { one, none};
    state curState;

	void Start () {
        nmc = GetComponent<NavMeshController>();
        _idleSpeed = nmc._idleSpeed;
        _chaseSpeed = nmc._chaseSpeed;
        nmc.enabled = false;
        agent = GetComponent<NavMeshAgent>();
        transform.position = _startPos.position;
        curState = state.none;
        agent.destination = transform.position;
	}
    void Update()
    {
        switch (curState)
        {
            case state.one:
                if (Vector3.Distance(transform.position, _endPos.position) < 0.2f)
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
        curState = state.one;
        agent.speed = _idleSpeed;
        agent.destination = _endPos.position;
    }

    private void _despawn()
    {
        GameManager.instance.player.GetComponent<ActivateDome>().spawnDomes = true;
        curState = state.none;
        nmc.enabled = true;
        enabled = false;
    }
}
