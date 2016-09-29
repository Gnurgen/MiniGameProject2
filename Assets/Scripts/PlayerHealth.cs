using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
    
    public int health = 3;
    public float regenTime = 5.0f;
    public int amountHealthRegenerated = 1;
    public GameObject enemy;
    public float enemyAttackDist = 1.0f;
    public float timeBetweenAttack = 5.0f;
    public float chanceforSecondAttackHit = 0.5f;

    private float currentHealth;
    private float currentregenTime;
    private float currentAttackTime;
    private float playerEnemyDistance;
    private Rigidbody enemyBody;
    private bool playerHit = false;
    void Start () {

        currentHealth = health;
        currentregenTime = regenTime;
        currentAttackTime = 0;
        GameManager.instance.OnPlayerTakeDamage += LoseLife;
        enemyBody = enemy.GetComponent<Rigidbody>();
    }
    void Update() {
        regenerate();
        playerEnemyDistance = Vector3.Distance(enemyBody.position, transform.position);

        if (playerEnemyDistance <= enemyAttackDist) {
            Debug.Log("Enemy near!");
            if (currentAttackTime <= 0)
            {
                GameManager.instance.EnemyAttack();
                rollIfHit();
                currentAttackTime = timeBetweenAttack;
            }
            else
            {
                currentAttackTime -= Time.deltaTime;
                Debug.Log("Preparing attack");
            }
        }
        else{ }
        Debug.Log("Health: "+ currentHealth);
            
    }

    private void rollIfHit() {
        if (playerHit == false)
        {
            Debug.Log("First Hit!");
            GameManager.instance.EnemyAttackHit(1);
            LoseLife(1);
            playerHit = true;
        }
        else {
            if (Random.value <= chanceforSecondAttackHit)
            {
                Debug.Log("Second Hit!");
                GameManager.instance.EnemyAttackHit(1);
                LoseLife(1);
                playerHit = false;
            }
            else
            {
                playerHit = false;
                Debug.Log("Miss!");
            }
        }

    }

    private void regenerate() {
        if (currentregenTime >= 0)
            currentregenTime -= Time.deltaTime;
        else
        {
            if (currentHealth < health)
            {
                GameManager.instance.PlayerRecover(amountHealthRegenerated);
                GainLife();
                currentregenTime = regenTime;
            }
            else
                currentregenTime = regenTime;
        }
    }
    private void GainLife()
    {
        currentHealth+= amountHealthRegenerated;
    }

    private void LoseLife(int value) {
        currentHealth-=value;
    }


}
