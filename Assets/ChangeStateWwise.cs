using UnityEngine;
using System.Collections;

public class ChangeStateWwise : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            AkSoundEngine.SetState("Ending", "Void");
            //GameManager.instance.audioManager
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            AkSoundEngine.SetState("Ending", "Forest");
            //GameManager.instance.audioManager
        }
    }
}
