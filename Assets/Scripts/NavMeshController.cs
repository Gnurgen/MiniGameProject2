using UnityEngine;
using System.Collections;

public class NavMeshController : MonoBehaviour {
	NavMeshAgent agent;
	[SerializeField]
	Transform cage;
	enum state {idle, reset, chase};
	private state curState;
	BoxCollider bCol;
	SphereCollider sCol;
	Vector3 idleTar;
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		bCol = cage.GetChild (0).GetComponent<BoxCollider> ();
		sCol = cage.GetChild (0).GetComponent<SphereCollider> ();
		curState = state.idle;
		idleTar = getRndIdle ();
		agent.destination = idleTar;
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (transform.position, idleTar) < 0.2f) {
			idleTar = getRndIdle ();
			agent.destination = idleTar;
		}
	}

	void setCage(Transform newCage){
		cage = newCage;
		bCol = cage.GetChild (0).GetComponent<BoxCollider> ();
		sCol = cage.GetChild (0).GetComponent<SphereCollider> ();
		transform.position = cage.GetChild (0).position;
		agent.destination = idleTar;
		curState = state.idle;
	}

	Vector3 getRndIdle(){
		if (bCol != null) {
			return new Vector3 (Random.Range (cage.position.x - bCol.size.x / 2, cage.position.x + bCol.size.x / 2), transform.position.y, Random.Range (cage.position.z - bCol.size.z / 2, cage.position.z + bCol.size.z / 2));
		} else {
			Vector3 temp = Random.insideUnitSphere * sCol.radius + cage.GetChild (0).position;
			return new Vector3(temp.x,transform.position.y, temp.z);
		}
	}
}
