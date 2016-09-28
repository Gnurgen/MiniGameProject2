using UnityEngine;
using System.Collections;

public class FenceTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == GameManager.instance.player)
            GameManager.instance.enemy.GetComponent<OneShotAnis>().playOneShot();
    }
}
