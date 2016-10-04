using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FroztVignette : MonoBehaviour
{
    public float fadeDuration = 2.0f;
    public float fadeInDuration = 0.5f;
    public float frostDistance = 20.0f;
    [SerializeField]
    [Range(1,4)]
    private int _fadeWithFrostImg;
    private Image vignette;
    private Image[] frost;
    private Image[] darkness;
    private float currentDuration;
    private Transform playerBody;
    private float playerEnemyDistance, tarFadeVal, vignFade;
    private float[] fadeVal;


    void Start()
    {
        playerBody = GameManager.instance.player.transform;
        vignette = GameObject.Find("MonsterGUI").transform.GetChild(0).GetComponent<Image>();
        frost = new Image[GameObject.Find("MonsterGUI").transform.GetChild(1).childCount];
        darkness = new Image[GameObject.Find("MonsterGUI").transform.GetChild(2).childCount];

        _fadeWithFrostImg = frost.Length - _fadeWithFrostImg;
        fadeVal = new float[frost.Length];

        for (int i = 0; i < frost.Length; i++)
        {
            frost[i] = GameObject.Find("MonsterGUI").transform.GetChild(1).GetChild(i).GetComponent<Image>();
        }
        for (int i = 0; i < darkness.Length; i++)
        {
            darkness[i] = GameObject.Find("MonsterGUI").transform.GetChild(2).GetChild(i).GetComponent<Image>();
            darkness[i].CrossFadeAlpha(0, 0, true);
        }
        GameManager.instance.OnEnemyAttackHit += ResetDarknessVignette;
        GameManager.instance.OnEnemyAttackHit += Darkness;
    }

    void Update() {
        playerEnemyDistance = Vector3.Distance(playerBody.position, transform.position);
        Frost();
    }


    void ResetDarknessVignette(int i) {
        for (int j = 0; i < frost.Length; i++)
        {
            frost[j].CrossFadeAlpha(0, 0, true);
        }
    }
    void Frost() {
        for(int x = 0; x<frost.Length; ++x)
        {
            tarFadeVal = 1 - playerEnemyDistance / (frostDistance - frostDistance * ( (float)x / frost.Length));
            if(tarFadeVal!=fadeVal[x])
                fadeVal[x] = Mathf.Lerp(fadeVal[x], tarFadeVal, 0.1f);
            if (Mathf.Abs(tarFadeVal - fadeVal[x]) < 0.05f)
                fadeVal[x] = tarFadeVal;

            if (x == 0)
                vignette.color = new Vector4(fadeVal[x] * _fadeWithFrostImg, fadeVal[x] * _fadeWithFrostImg, fadeVal[x] * _fadeWithFrostImg, 1);

            if (playerEnemyDistance <= frostDistance - (frostDistance * ((float)x / frost.Length)))
                frost[x].color = new Vector4(255, 255, 255, fadeVal[x]);
            else
                frost[x].color = new Vector4(255, 255, 255, 0);
        }
    }

    void Darkness(int i)
    {
        StartCoroutine(darknessFadeWait(fadeDuration, fadeInDuration));
    }


    IEnumerator darknessFadeWait(float time1, float time2)
    {

        for (int i = 0; i < darkness.Length; i++)
        {

            darkness[i].CrossFadeAlpha(1, fadeInDuration, true);
            yield return new WaitForSeconds(time2);
        }
        for (int i = darkness.Length - 1; i >= 0; i--)
        {
            darkness[i].CrossFadeAlpha(0, fadeDuration, true);
            yield return new WaitForSeconds(time1);
        }

    }
}
