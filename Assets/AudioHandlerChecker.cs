using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class AudioHandlerChecker : MonoBehaviour {

	// Use this for initialization
	void Start () {

        //THIS IS FOR THE EDITOR ONLY

        if (!GameObject.Find("AudioManager"))
            SceneManager.LoadScene(0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
