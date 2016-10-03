using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndGameInteraction : MonoBehaviour {

    public Image menuButton;

    public Color startColor;
    public Color endColor;

    public float menuAppearDuration;
    public float waitForFadeTime;

    float localTime;

    bool startFading;

    void Start()
    {
        menuButton.color = startColor;
        StartCoroutine(ButtonFadeIn(waitForFadeTime));

    }

    void Update()
    {
        if(startFading)
        {
            localTime += Time.deltaTime;
            menuButton.color = Color.Lerp(startColor, endColor, localTime / menuAppearDuration);
        }
    }

    public void ToMenu()
    {
        GameManager.instance.LeaveGame();
    }

    public void Respawn()
    {
        GameManager.instance.StartGame();
    }


    IEnumerator ButtonFadeIn(float time)
    {
        yield return new WaitForSeconds(time);
        startFading = true;
    }

}
