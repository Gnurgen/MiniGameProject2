using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadNextSceneFromInitialize : MonoBehaviour {

    
	// Use this for initialization
	void Start () {
		SceneManager.LoadScene("StartScene.unity");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
