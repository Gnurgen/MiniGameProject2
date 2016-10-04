using UnityEngine;
using System.Collections;

public class EnemyAnimator : MonoBehaviour {


    Animator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        GameManager.instance.OnEnemyAttack += EnemyAttack;
        GameManager.instance.OnEnemyAggro += EnemyAggro;
        GameManager.instance.OnEnemyIdle += EnemyIdle;
        GameManager.instance.OnEnemyDespawn += EnemyIdle;

    }
    void EnemyIdle()
    {
        anim.SetTrigger("Idle");
        anim.SetBool("Aggroed", false);
    }

    void EnemyAttack()
    {
        anim.SetTrigger("Attack");
    }
 
    void EnemyAggro()
    {
        anim.SetBool("Aggroed",true);
        
    }
    void AttackHitEvent()
    {
        GameManager.instance.EnemyAttackHit(1); //AttackHitSound
    }
    void EnemyFootStepEvent()
    {
        GameManager.instance.EnemyStep();  //EnemyStepSound
    }// Update is called once per frame
    void Update () {
	
	}
}
