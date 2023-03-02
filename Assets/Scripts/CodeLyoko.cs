using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeLyoko : MonoBehaviour
{
    [SerializeField]
    private Transform _deathZone;
    [SerializeField]
    private GameObject _externalSphere;
    [SerializeField]
    private float _scaleFactor = 0.1f;
    private Vector3 _scaleVector;

    private bool _upScale = false;

    private void Start(){
        _scaleVector = new Vector3(_scaleFactor,_scaleFactor,_scaleFactor);
    }
    
    private void Update(){
        if (_upScale){
            _externalSphere.transform.localScale += _scaleVector;
        }
    }

    private void OnTriggerEnter(Collider other){
        other.gameObject.transform.position = _deathZone.position;
        Destroy(_externalSphere);
        _upScale = false;
    }

    public void StartScaling(){
        _upScale = true;
    }
}
