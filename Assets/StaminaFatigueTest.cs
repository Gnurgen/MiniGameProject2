using UnityEngine;
using System.Collections;

public class StaminaFatigueTest : MonoBehaviour {


    public float Stamina = 0;
	// Use this for initialization
	void Start () {
    }

    // Update is called once per frame

    void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
            AkSoundEngine.PostEvent("FootStep",gameObject);

        if(Input.GetKeyDown(KeyCode.W))
            AkSoundEngine.SetSwitch("FootSteps", "Walk",gameObject);

        if (Input.GetKeyDown(KeyCode.R))
            AkSoundEngine.SetSwitch("FootSteps", "Run",gameObject);

        AkSoundEngine.SetRTPCValue("staminaPar", Stamina);
    }
}
