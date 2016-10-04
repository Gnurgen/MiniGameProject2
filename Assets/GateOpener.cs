using UnityEngine;
using System.Collections;

public class GateOpener : MonoBehaviour {

    public GameObject gateL, gateR;

    public int musicBoxCount = 0;

    private bool activated = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(GameManager.instance.musicBoxCount == musicBoxCount && !activated)
        {
            gateL.transform.localRotation = Quaternion.Euler(0, 90, 0);
            gateR.transform.localRotation = Quaternion.Euler(0, -90, 0);
            activated = true;
        }
    }
}
