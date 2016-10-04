using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextFader : MonoBehaviour {

    private Text _text;

    private bool startFadingIn;
    private bool startFadingOut;

    private float localTime;

    public Color startColor;
    public Color endColor;

    public float waitForFadeIn = 1.0f;
    public float fadeInDuration = 0.5f;
    public float fadeOutDuration = 0.5f;
    public float displayDuration = 5.0f;

    void Start ()
    {
        GameObject danishIntroText = GameObject.Find("IntroTextDanish");
        GameObject englishIntroText = GameObject.Find("IntroTextEnglish");

        if (GameManager.language == GameManager.Language.Danish)
        {
            danishIntroText.SetActive(true);
            englishIntroText.SetActive(false);
        }
        else
        {
            danishIntroText.SetActive(false);
            englishIntroText.SetActive(true);
        }

        _text = FindObjectOfType<Text>();
        _text.color = startColor;
        StartCoroutine(TextFade(waitForFadeIn));
    }

    void Update()
    {
        if (startFadingIn)
        {
            localTime += Time.deltaTime;
            _text.color = Color.Lerp(startColor, endColor, localTime / fadeInDuration);
        }

        if (startFadingOut)
        {

            localTime += Time.deltaTime;
            _text.color = Color.Lerp(endColor, startColor, localTime / fadeOutDuration);
        }
    }

    IEnumerator TextFade(float time)
    {
        yield return new WaitForSeconds(time);
        startFadingIn = true;
        yield return new WaitForSeconds(fadeInDuration);
        localTime = 0;
        startFadingIn = false;
        yield return new WaitForSeconds(displayDuration);
        startFadingOut = true;
        yield return new WaitForSeconds(fadeOutDuration);

        GameManager.instance.StartGame();
    }
}
