using UnityEngine;
using System.Collections;
using System;

public class MusicBoxAnimation : MonoBehaviour {

    Animator anim;
    bool animationComplete = false;
    [SerializeField]
    Transform GrandChild;
    public GameObject ParticlePuff;
    void Start () {
        GrandChild = transform.GetChild(0).GetChild(0);
        anim = GetComponent<Animator>();
        // Music Box Events
        GameManager.instance.OnMusicBoxRewindComplete += MB_Rewind_Complete;
        GameManager.instance.OnMusicBoxRewindStart += MB_Rewind_Play;
        GameManager.instance.OnMusicBoxRewindStop += MB_Rewind_Stop;
        GameManager.instance.OnMusicBoxMove += MB_Move;
    }

    private void MB_Move()
    {
        GameObject particlePuff = (GameObject)Instantiate(ParticlePuff, GrandChild.GetChild(0).position + GrandChild.localPosition- GrandChild.GetChild(0).localPosition, transform.rotation);
        Destroy(particlePuff, 2f);
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
       
    }

    
  

	void Update () {
	
	}

}
