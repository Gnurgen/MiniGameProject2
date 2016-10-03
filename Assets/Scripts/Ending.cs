using UnityEngine;
using System.Collections;

public class Ending : MonoBehaviour {
    private int musicbox;
    private bool ending;
    private bool playerFacingDoor;
    private GameObject lighBulb;
    private GameObject coffinLit;

    private Transform playerBody;
    public float pauseBeforeTurnOffLight = 2;
    public float doorspeed = 0.5f;
    private float cPause;
    
    void Start () {
        playerBody = GameManager.instance.player.transform;
        lighBulb = GameObject.Find("LightBulb");
        coffinLit = GameObject.Find("coffinHatch_geo");
    }
    
    void Update()
    {
           musicbox = GameManager.instance.musicBoxCount;
        
        if (musicbox >= 5) { // Number of the last music box
            ending = true;
        }
        if (ending) {
            checkFacingDir();
        }       
    }

    void checkFacingDir() {
        if (playerBody.transform.eulerAngles.y >= 160 && playerBody.transform.eulerAngles.y <= 190)
        {
            closeCoffin();
        }
    }

    void closeCoffin() {
        if (coffinLit.transform.localPosition.x <= -0.1)
        {
            coffinLit.transform.eulerAngles = new Vector3(90, 180, 0);
            coffinLit.transform.Translate(Vector3.right * Time.deltaTime*doorspeed, Space.Self);
            coffinLit.transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
        }
        else {
            if (cPause >= pauseBeforeTurnOffLight)
                lighBulb.SetActive(false);
            else
                cPause += Time.deltaTime;
        }
    }
}
