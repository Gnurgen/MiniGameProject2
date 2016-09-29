using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
    
    public int health = 2;
    public float regenTime = 5.0f;
    public float regenTimeAfterHit = 10.0f;
    public int amountHealthRegenerated = 1;

    private float currentHealth;
    private float currentregenTime;

    void Start () {

        currentHealth = health;
        currentregenTime = regenTime;
        GameManager.instance.OnPlayerTakeDamage += LoseLife;
        GameManager.instance.OnEnemyAttack += ResetTimer;

    }
    void Update() {
        regenerate();
        if (currentHealth == 0)
            Debug.Log("Player dead");
        //Debug.Log(currentHealth);   
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
    private void ResetTimer() {
        currentregenTime = regenTimeAfterHit;
        //Debug.Log("Reset regen timer: " + currentregenTime);

    }
    private void GainLife()
    {
        currentHealth+= amountHealthRegenerated;
    }

    private void LoseLife(int value) {
        currentHealth-=value;
    }


}
