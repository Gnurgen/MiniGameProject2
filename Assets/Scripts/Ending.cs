﻿using UnityEngine;
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
    private bool playAnimation = false;
    float SecondsOfAnimation = 50;
    
    void Start () {
        playerBody = GameManager.instance.player.transform.GetChild(0);
        lighBulb = GameObject.Find("LightBulb");
        coffinLit = GameObject.Find("coffinHatch_geo_move").transform;
        coffinLitTar = GameObject.Find("coffinHatch_geo_tar").transform;
        GameManager.instance.OnMusicBoxLast += SetEnding;
    }
    
    void Update()
    {
        if (ending)
        {
            checkFacingDir();
        }       
    }
    void SetEnding()
    {
        ending = true;
    }
    void checkFacingDir() {
        if (playerBody.transform.eulerAngles.y >= 160 && playerBody.transform.eulerAngles.y <= 190)
        {
            closeCoffin();
            GameManager.instance.KnockOnCoffin();
        }
    }

    void closeCoffin() {

        if (step <=1)
        {
            step += Time.deltaTime / SecondsOfAnimation;
            coffinLit.position = Vector3.MoveTowards(coffinLit.position, coffinLitTar.position, step);
            coffinLit.rotation = coffinLitTar.rotation;
        
        }
        else {
            GameManager.instance.audioManager.AmbienceStop();




            if (cPause >= pauseBeforeTurnOffLight)
            {
                StartCoroutine(EndGame(5));
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
