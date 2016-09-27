using UnityEngine;
using System.Collections;

public class InputForTestingDelegates : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            GameManager.instance.MusicBoxRewindStart();
        if (Input.GetKeyDown(KeyCode.RightArrow))
            GameManager.instance.MusicBoxRewindStop();
	}
}
