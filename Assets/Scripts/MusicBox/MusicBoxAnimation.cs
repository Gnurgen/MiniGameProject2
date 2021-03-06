﻿using UnityEngine;
using System.Collections;
using System;

public class MusicBoxAnimation : MonoBehaviour {

    Animator anim;
    bool animationComplete = false;
    

    void Start () {

       
        anim = GetComponent<Animator>();
        // Music Box Events
        GameManager.instance.OnMusicBoxRewindComplete += MB_Rewind_Complete;
        GameManager.instance.OnMusicBoxRewindStart += MB_Rewind_Play;
        GameManager.instance.OnMusicBoxRewindStop += MB_Rewind_Stop;
        GameManager.instance.OnMusicBoxMove += MB_Move;
        GameManager.instance.OnGateOpen += MB_LastOne;
    }
    private void MB_LastOne()
    {
        anim.SetBool("LastBox", true);
       

    }
    private void MB_Move()
    {
        animationComplete = false;
        anim.ResetTrigger("IsRewinding");
  
    }
   
    private void MB_Rewind_Complete()
    {
       
        animationComplete = true;
        anim.ResetTrigger("IsRewinding");
        anim.speed = 1;
    }

    private void MB_Rewind_Stop()
    {
            anim.ResetTrigger("IsRewinding");
          if(!animationComplete)
            anim.speed = 0;
    }

    private void MB_Rewind_Play()
    {

        anim.SetTrigger("IsRewinding");
        if(!animationComplete)
        anim.speed = 1;
       if(anim.GetBool("LastBox") == true)
        {
            StartCoroutine(LastBoxAni(2f));
        }
    }
    IEnumerator LastBoxAni(float time)
    {   yield return new WaitForSeconds(time);
        GameManager.instance.MusicBoxLast();
    }

}
