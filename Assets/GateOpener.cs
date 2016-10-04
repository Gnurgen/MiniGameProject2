using UnityEngine;
using System.Collections;

public class GateOpener : MonoBehaviour {

    public GameObject gateL, gateR;



	// Use this for initialization
	void Start () {
        GameManager.instance.OnGateOpen += OpenTheGate;

    }
	
	// Update is called once per frame
	void OpenTheGate ()
    {
            gateL.transform.localRotation = Quaternion.Euler(0, 90, 0);
            gateR.transform.localRotation = Quaternion.Euler(0, -90, 0);
    }
}
