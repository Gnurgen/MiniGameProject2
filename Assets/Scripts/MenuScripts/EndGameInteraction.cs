using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndGameInteraction : MonoBehaviour {

    public bool whiteBackground;

    public Image menuButton;

    public Color startColor;
    public Color endColor;

    public float menuAppearDuration;
    public float waitForFadeTime;

    private float localTime;
    private bool startFading;

    void Start()
    {
        GameObject danishDeathText = GameObject.Find("DeathTextDanish");
        GameObject englishDeathText = GameObject.Find("DeathTextEnglish");

        if (GameManager.language == GameManager.Language.Danish)
        {
            danishDeathText.SetActive(true);
            englishDeathText.SetActive(false);
        }
        else
        {
            danishDeathText.SetActive(false);
            englishDeathText.SetActive(true);

            if (whiteBackground)
            {
                GameObject.Find("Respawn").GetComponent<Image>().sprite = Resources.Load<Sprite>("AgainBlackEnglish");
                GameObject.Find("BACKGROUND").GetComponent<Image>().sprite = Resources.Load<Sprite>("DeathBackgroundWhite");
            }
            else
            {
                GameObject.Find("Respawn").GetComponent<Image>().sprite = Resources.Load<Sprite>("AgainWhiteEnglish");
                GameObject.Find("BACKGROUND").GetComponent<Image>().sprite = Resources.Load<Sprite>("DeathBackgroundBlack");
            }
        }

        if (menuButton)
        {
            menuButton.color = startColor;
            StartCoroutine(ButtonFadeIn(waitForFadeTime));
        }
    }

    void Update()
    {
        if(menuButton && startFading)
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
