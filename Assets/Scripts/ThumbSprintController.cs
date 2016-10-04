using UnityEngine;
using System.Collections;

public class ThumbSprintController : MonoBehaviour {

    [SerializeField]
    private bool _blink;
    [SerializeField]
    private float _onScreenTime, _offScreenTime;
    [SerializeField]
    private float _showDuration;
    [SerializeField]
    private float _delayDuration;
    private GameObject child;
    private bool _doShow;

    void Start()
    {
        child = transform.GetChild(0).gameObject;
        child.SetActive(false);
        StartCoroutine(startupDelay(_delayDuration));
    }

    public void ShowThumbs()
    {
        _doShow = true;
        child.SetActive(true);
        if (_blink)
            onScreenBlink();
        Invoke("showPrint", _showDuration);
    }
    private void showPrint()
    {
        _doShow = false;
        child.transform.GetChild(1).gameObject.SetActive(true);
        child.transform.GetChild(0).gameObject.SetActive(true);
        child.SetActive(false);
    }
    private void onScreenBlink()
    {
        if (_doShow)
        {
            child.SetActive(true);
            Invoke("offScreenBlink", _onScreenTime);
        }
    }
    private void offScreenBlink()
    {
        if (_doShow)
        {
            child.SetActive(false);
            Invoke("onScreenBlink", _offScreenTime);
        }
    }

    private void showFirstHint()
    {
        child.SetActive(true);
        child.transform.GetChild(1).gameObject.SetActive(false);
        if (_blink)
            onScreenHint();
        Invoke("showPrint", _showDuration);
    }
    private void onScreenHint()
    {
        child.transform.GetChild(0).gameObject.SetActive(true);
        Invoke("offScreenHint", _offScreenTime);
    }
    private void offScreenHint()
    {
        child.transform.GetChild(0).gameObject.SetActive(false);
        Invoke("onScreenHint", _offScreenTime);
    }

    IEnumerator startupDelay(float time)
    {
        yield return new WaitForSeconds(time);
        showFirstHint();
    }
}
