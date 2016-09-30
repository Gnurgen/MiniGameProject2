using UnityEngine;
using System.Collections;

public class ThumbSprintController : MonoBehaviour {

    [SerializeField]
    private float _showDuration;
    [SerializeField]
    private bool _blink;
    [SerializeField]
    private float _onScreenTime, _offScreenTime;
    private GameObject child;
    private bool _doShow;

    void Start()
    {
        child = transform.GetChild(0).gameObject;
        child.SetActive(false);
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
}
