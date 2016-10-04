using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
    
    public int health = 2;
    public float regenTime = 5.0f;
    public float regenTimeAfterHit = 10.0f;
    public int amountHealthRegenerated = 1;
    [SerializeField]
    private float _deathFadeTime;

    private float currentHealth, _normFade, _fadeTimer;
    private int deltaFade;
    private bool _dead = false;
    private float currentregenTime;
    private Transform _deathGUI;

    void Start () {
        _deathGUI = GameObject.Find("ThumbPrint").transform.GetChild(1);
        currentHealth = health;
        currentregenTime = regenTime;
        GameManager.instance.OnPlayerTakeDamage += LoseLife;
        GameManager.instance.OnEnemyAttack += ResetTimer;
    }
    void Update() {
        if(!_dead)
            regenerate();
        if (currentHealth <= 0)
        {
            _dead = true;
            _fadeTimer += Time.deltaTime;
            _normFade = 1 - _fadeTimer / _deathFadeTime;
            _deathGUI.GetChild(0).GetComponent<Image>().color = new Vector4(1,1,1, 1-_normFade);
            _deathGUI.GetChild(1).GetComponent<RectTransform>().offsetMin = new Vector2(0, 1536*_normFade);
            _deathGUI.GetChild(2).GetComponent<RectTransform>().offsetMax = new Vector2(0, -1536*_normFade);
        }
        if (_fadeTimer >= _deathFadeTime)
            eyesClosed();
           
    }

 
    private void regenerate() {
        if (currentregenTime >= 0)
            currentregenTime -= Time.deltaTime;
        else
        {
            if (currentHealth < health)
            {
                GameManager.instance.PlayerRecover(amountHealthRegenerated);
                currentHealth += amountHealthRegenerated;
                currentregenTime = regenTime;
            }
            else
                currentregenTime = regenTime;
        }
    }
    private void ResetTimer() {
        currentregenTime = regenTimeAfterHit;
    }

    private void LoseLife(int value) {
        currentHealth-=value;
    }

    private void eyesClosed()
    {
        _dead = false;
        _fadeTimer = 0;
        _deathGUI.GetChild(0).GetComponent<Image>().color = Vector4.zero;
        _deathGUI.GetChild(1).GetComponent<RectTransform>().offsetMin = new Vector2(0, 1536);
        _deathGUI.GetChild(2).GetComponent<RectTransform>().offsetMax = new Vector2(0, 1536);
        GameManager.instance.PlayDeathScene_Monster();
    }

}
