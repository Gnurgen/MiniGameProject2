using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextFader : MonoBehaviour {

    Text _text;

    bool startFadingIn;
    bool startFadingOut;

    float localTime;

    [SerializeField]
    Color startColor;
    [SerializeField]
    Color endColor;

    [SerializeField]
    float waitForFadeDuration;
    [SerializeField]
    float fadeInDuration;
    [SerializeField]
    float fadeOutDuration;
    [SerializeField]
    float textOnScreenDuration;



    void Start ()
    {
        _text = FindObjectOfType<Text>();
        _text.color = startColor;
        StartCoroutine(TextFade(waitForFadeDuration));
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
        yield return new WaitForSeconds(textOnScreenDuration);
        startFadingOut = true;
        yield return new WaitForSeconds(fadeOutDuration);

        GameManager.instance.StartGame();
    }
}
