using UnityEngine;
using System.Collections;

public class ZoomBoxToPlayer : MonoBehaviour {

    private Transform _player, _mBox;
    private Vector3 _dir, _initPos;

    [SerializeField]
    private int _zoomTime, _startDistToBox;
    [SerializeField]
    private AnimationCurve _zoomBehaviour;
    private float _normTime = 0, _initDist, _deltaTime = 0;

	void OnEnable () {
        _player = GameManager.instance.player.transform;
        _mBox = GameManager.instance.musicBox.transform;
        _dir = (_mBox.position - _player.position).normalized; //Get direction vector from box to player
        transform.position = _mBox.position - _dir * _startDistToBox;
        transform.LookAt(_mBox);
        _initPos = transform.position;
        _initDist = Vector3.Distance(_initPos, _player.position);
	}
	
	void Update () {
        _deltaTime += Time.deltaTime;
        _normTime = _deltaTime/_zoomTime;
        transform.position = _initPos - _dir * (_initDist * _zoomBehaviour.Evaluate(_normTime));
        if (_normTime >= 1)
        {
            _normTime = 0;
            _deltaTime = 0;
            enabled = false;
            GameManager.instance.player.GetComponent<PlayerControls>().canMove = true;
        }
	}
}
