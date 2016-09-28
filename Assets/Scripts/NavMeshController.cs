using UnityEngine;
using System.Collections;

public class NavMeshController : MonoBehaviour {
	private NavMeshAgent agent;
	private Transform cage;
	private enum state {idle, chase};
	private state curState;
	private BoxCollider bCol;
	private SphereCollider sCol;
	private Vector3 idleTar, _dir;
    private bool _noMove;

    [SerializeField]
    private float _idleSpeed, _chaseSpeed, _chaseTime;

    void Start () {
		curState = state.idle;
        GameManager.instance.OnEnemyAggro += startChase;
	}

    void Update() {
        switch (curState)
        { 
            case state.idle:
                if (Vector3.Distance(transform.position,idleTar) < 0.3f && !_noMove)
                {
                    idleTar = getRndIdle();
                    agent.destination = idleTar;
                }
                break;
            case state.chase:
                agent.destination = GameManager.instance.player.transform.position;
                break;
        }
	}

	public void setCage(Transform newCage){
        if (agent == null)
            agent = GetComponent<NavMeshAgent>();
		cage = newCage;
		bCol = cage.GetChild (0).GetComponent<BoxCollider>();
		sCol = cage.GetChild (0).GetComponent<SphereCollider>();
        transform.position = new Vector3(cage.GetChild(0).position.x, transform.position.y, cage.GetChild(0).position.z);
        idleTar = transform.position;
		agent.destination = idleTar;
        agent.speed = _idleSpeed;
        _noMove = cage.GetComponent<CageStandStill>().StandStill;
		curState = state.idle;
	}

	private Vector3 getRndIdle(){
		if (bCol != null) {
			return new Vector3 (Random.Range (cage.position.x - bCol.size.x / 2, cage.position.x + bCol.size.x / 2), 
                                              transform.position.y, Random.Range (cage.position.z - bCol.size.z / 2, cage.position.z + bCol.size.z / 2));
		} else {
			Vector3 temp = Random.insideUnitSphere * sCol.radius + cage.GetChild (0).position;
			return new Vector3(temp.x,transform.position.y, temp.z);
		}
	}

    private void startChase()
    {
        curState = state.chase;
        agent.speed = _chaseSpeed;
    }
    private void startIdle()
    {
        curState = state.idle;
        agent.speed = _idleSpeed;
        idleTar = new Vector3(cage.GetChild(0).position.x, transform.position.y, cage.GetChild(0).position.z);
        agent.destination = idleTar;
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.transform == cage)
            Invoke("startIdle", _chaseTime);
    }
}
