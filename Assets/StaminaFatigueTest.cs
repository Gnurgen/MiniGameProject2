using UnityEngine;
using System.Collections;

public class StaminaFatigueTest : MonoBehaviour {


    public float Stamina = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        AkSoundEngine.SetRTPCValue("StaminaPar", Stamina);
	}
}
