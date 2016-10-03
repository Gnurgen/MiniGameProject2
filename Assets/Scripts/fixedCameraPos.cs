using UnityEngine;
using System.Collections;

public class fixedCameraPos : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.position = transform.parent.GetChild(0).position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
