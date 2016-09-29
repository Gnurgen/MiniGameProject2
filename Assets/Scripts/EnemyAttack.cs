using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{

    public GameObject player;
    public float enemyAttackDist = 1.0f;
    public float timeBetweenAttack = 5.0f;
    public float chanceforSecondAttackHit = 0.5f;

    private float currentAttackTime;
    private float playerEnemyDistance;
    private Rigidbody playerBody;
    private bool playerHit = false;

    // Use this for initialization
    void Start()
    {
        currentAttackTime = 0;
        playerBody = player.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        playerEnemyDistance = Vector3.Distance(playerBody.position, transform.position);

        if (playerEnemyDistance <= enemyAttackDist)
        {
           // Debug.Log("Enemy near!");
            if (currentAttackTime <= 0)
            {
                GameManager.instance.EnemyAttack();
                rollIfHit();
                currentAttackTime = timeBetweenAttack;
            }
            else
            {
                currentAttackTime -= Time.deltaTime;
             //   Debug.Log("Preparing attack");
            }
        }
        else { }
    }

    private void rollIfHit()
    {
        if (playerHit == false)
        {
            //Debug.Log("First Hit!");
            GameManager.instance.EnemyAttackHit(1);
            GameManager.instance.PlayerTakeDamage(1);
            playerHit = true;
        }
        else
        {
            if (Random.value <= chanceforSecondAttackHit)
            {
                //Debug.Log("Second Hit!");
                GameManager.instance.EnemyAttackHit(1);
                GameManager.instance.PlayerTakeDamage(1);
                playerHit = false;
            }
            else
            {
                playerHit = false;
                //Debug.Log("Miss!");
            }
        }
    }
}