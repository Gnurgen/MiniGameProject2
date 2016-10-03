using UnityEngine;
using System.Collections;

public class ScreenShake : MonoBehaviour {

    private Transform child;
    private bool _doShake;
    [SerializeField]
    private int shakeStrength;
    [SerializeField]
    private float _shakeDuration;
    private float strength, count;
    Vector3 orgPos;

	// Use this for initialization
	void Start () {
        child = transform.GetChild(0);
        orgPos = transform.GetChild(1).localPosition;
        strength = (shakeStrength / 10.0f) / 2.0f;
        GameManager.instance.OnEnemyAttackHit += _screenShake;
	}
	
	// Update is called once per frame
	void Update () {
        if (_doShake)
            child.localPosition = child.up * Random.Range(-strength, strength) + child.right * Random.Range(-strength, strength);
	}

    private void _screenShake(int dmg)
    {
        if (!_doShake)
        {
            _doShake = true;
            Invoke("stopShake", _shakeDuration);
        }
    }

    private void stopShake()
    {
        _doShake = false;
        child.localPosition = orgPos;
    }
}
