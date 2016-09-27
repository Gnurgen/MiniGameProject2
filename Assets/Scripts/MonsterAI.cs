using UnityEngine;
using System.Collections;

public class MonsterAI : MonoBehaviour {

	enum state {idle, aggro, reseting};

	public GameObject patrolCage;
	public GameObject cage;
	public float aggroSpeed;
	public float idleSpeed;
	public float resetSpeed;

	private Vector3 moveDir;

	[SerializeField]
	state currentState;
	[SerializeField]
	float resetTimer;
	[SerializeField]
	bool standStill;
	[SerializeField]
	GameObject player;
	// Use this for initialization
	void Start () {
		currentState = state.idle;
		moveDir = Vector3.forward;
		SetStandStill ();
		player = GameManager.instance.player;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		switch (currentState) {
		case state.idle:
			if (!standStill) {
				transform.position += moveDir * Time.deltaTime;
			}
			break;
		case state.aggro:
			break;
		case state.reseting:
			transform.position = Vector3.MoveTowards (transform.position, cage.transform.position, Time.deltaTime * resetSpeed);
			if (Vector3.Distance (transform.position, cage.transform.position) < 1) {
				currentState = state.idle;
			}
			break;
		default:
			break;
		}
	}

	void OnTriggerExit(Collider coll){
		print ("BØH");
		if (coll.gameObject == cage) {
			Invoke ("ResetMonster", resetTimer);
		}
		else if (coll.gameObject == patrolCage && currentState == state.idle){
			Vector3 tempPos = patrolCage.transform.position + new Vector3(Random.Range(-1,1), 0 , Random.Range(-1,1));
			moveDir = (tempPos - transform.position).normalized;
			transform.LookAt (moveDir);
			//transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (moveDir) , 0.02f);
		}
	}

	void ResetMonster(){
		currentState = state.reseting;
	}

	void SetStandStill(){
		BoxCollider box = patrolCage.GetComponent<BoxCollider> ();
		SphereCollider sphere = patrolCage.GetComponent<SphereCollider> ();
		if (box != null) {
			standStill = box.size.x <= 1 && box.size.y <= 1 && box.size.z <= 1;
		}
		if (sphere != null) {
			standStill = sphere.radius <= 1;
		}
	}
}
