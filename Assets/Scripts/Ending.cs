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
    private float step=-1;
    private bool closeIt = false;
    private bool playAnimation = false;
    private bool stopItAll = false;
    float SecondsOfAnimation = 3;
    RaycastHit hit;
    Ray ray;
    void Start () {
        playerBody = GameManager.instance.player.transform.GetChild(0);
        lighBulb = GameObject.Find("LightBulb");
        coffinLit = GameObject.Find("coffinHatch_geo_move").transform;
        coffinLitTar = GameObject.Find("coffinHatch_geo_tar").transform;
        GameManager.instance.OnMusicBoxLast += SetEnding;
    }
    
    void FixedUpdate()
    {
        if (ending && !closeIt)
        {
            checkFacingDir();
        }       
    }
    void Update()
    {
        if(closeIt)
        {
            closeCoffin();
        }
    }
    void SetEnding()
    {
        ending = true;
    }
    void checkFacingDir() {

        if (Physics.Raycast(playerBody.position, playerBody.transform.forward, out hit))
        {
            if (hit.transform.tag == "Ending")
            {
                closeIt = true;
                GameManager.instance.KnockOnCoffin();
            }
        }
    }

    void closeCoffin() {

        if (step <=1)
        {
           
            step += (1 / SecondsOfAnimation) * Time.deltaTime;
            coffinLit.position = Vector3.MoveTowards(coffinLit.position, coffinLitTar.position, step);
            coffinLit.rotation = coffinLitTar.rotation;
            
        }
        else if(!stopItAll)
        {
            GameManager.instance.audioManager.AmbienceStop(); 
            StartCoroutine(EndGame(5));
            stopItAll = true;
        }
    }

    IEnumerator EndGame(float time)
    {
        lighBulb.SetActive(false);
        yield return new WaitForSeconds(time);
        GameManager.instance.PlayWinScene();
    }
}
