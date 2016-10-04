using UnityEngine;
using System.Collections;

public class Ending : MonoBehaviour {
    private int musicbox;
    private bool ending;
    private bool playerFacingDoor;
    private GameObject lighBulb;
    private Transform coffinLit;
    private Transform coffinLitTar;
    private Transform playerBody;
    public float pauseBeforeTurnOffLight = 2;
    public float doorspeed = 0.5f;
    private float cPause;
    private float step=0;
    public float SecondsOfAnimation;
    
    void Start () {
        playerBody = GameManager.instance.player.transform.GetChild(0);
        lighBulb = GameObject.Find("LightBulb");
        coffinLit = GameObject.Find("coffinHatch_geo").transform;
        coffinLitTar = GameObject.Find("coffinHatch_geo_tar").transform;
 
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
        if (step <=1)
        {
            step += Time.deltaTime / SecondsOfAnimation;
            coffinLit.position = Vector3.MoveTowards(coffinLit.position, coffinLitTar.position, step);
            coffinLit.rotation = Quaternion.RotateTowards(coffinLit.rotation, coffinLitTar.rotation, step);
           
            //coffinLit.transform.eulerAngles = new Vector3(90, 180, 0);
            //coffinLit.transform.Translate(Vector3.right * Time.deltaTime*doorspeed, Space.Self);
            //coffinLit.transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
        }
        else {
            if (cPause >= pauseBeforeTurnOffLight)
            {
                StartCoroutine(EndGame(1));
            }
            else
                cPause += Time.deltaTime;
        }
    }

    IEnumerator EndGame(float time)
    {
        lighBulb.SetActive(false);
        yield return new WaitForSeconds(time);
        GameManager.instance.PlayWinScene();
    }
}
