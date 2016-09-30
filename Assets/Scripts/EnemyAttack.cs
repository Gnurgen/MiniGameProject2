using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    float enemyAttackDist = 2.0f;
    public float timeBetweenAttack = 1.0f;
    public float chanceforSecondAttackHit = 0.5f;
    public long vibrationDuration = 10000;

    private float currentAttackTime;
    private float playerEnemyDistance;
    private Transform playerBody;
    private bool playerHit = false;


    // Use this for initialization
    void Start()
    {
        currentAttackTime = 0;
        playerBody = GameManager.instance.player.transform;
        GameManager.instance.OnEnemyAttackHit += AttackVibrate;
    }
    // Update is called once per frame
    void Update()
    {
        playerEnemyDistance = Vector3.Distance(playerBody.position, transform.position);
        if (playerEnemyDistance <= enemyAttackDist)
        {
            //Debug.Log("Enemy near!");
            if (currentAttackTime <= 0)
            {
                GameManager.instance.EnemyAttack();
                rollIfHit();
                currentAttackTime = timeBetweenAttack;
            }
            else
            {
                currentAttackTime -= Time.deltaTime;
               //Debug.Log("Preparing attack");
            }
        }
        else { }
    }

    public void AttackVibrate(int i)
    {

        //Handheld.Vibrate();
        Vibrator.Vibrate(vibrationDuration);
    }

    private void rollIfHit()
    {
        if (playerHit == false)
        {
            Debug.Log("First Hit!");
            GameManager.instance.EnemyAttackHit(1);
            GameManager.instance.PlayerTakeDamage(1);
            playerHit = true;
        }
        else
        {
            if (Random.value <= chanceforSecondAttackHit)
            {
                Debug.Log("Second Hit!");
                GameManager.instance.EnemyAttackHit(1);
                GameManager.instance.PlayerTakeDamage(1);
                playerHit = false;
            }
            else
            {
                playerHit = false;
                Debug.Log("Miss!");
            }
        }
    }
}