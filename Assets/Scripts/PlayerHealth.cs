using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
    
    public int health = 3;
    public float regenTime = 10.0f;
    public int amountHealthRegenerated = 1;

    private float currentHealth;
    private float currentTime;

    void Start () {
        currentHealth = 1;
        currentTime = regenTime;
        GameManager.instance.OnPlayerTakeDamage += LoseLife;
    }
    void Update() {
        regenerate();
        Debug.Log(currentHealth);
            
    }

    void regenerate() {
        if (currentTime >= 0)
            currentTime -= Time.deltaTime;
        else
        {
            if (currentHealth < health)
            {
                GameManager.instance.PlayerRecover(amountHealthRegenerated);
                GainLife();
                currentTime = regenTime;
            }
            else
                currentTime = regenTime;
        }
    }
    void GainLife()
    {
        currentHealth+= amountHealthRegenerated;
    }

    public void LoseLife(int value) {
        currentHealth-=value;
    }
}
