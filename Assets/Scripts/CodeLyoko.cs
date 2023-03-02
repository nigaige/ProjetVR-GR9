using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeLyoko : MonoBehaviour
{
    [SerializeField]
    private Transform _deathZone;
    [SerializeField]
    private GameObject _externalSphere;

    private bool _upScale = false;

    private void OnTriggerEnter(Collider other){
        other.gameObject.transform.position = _deathZone.position;
        Destroy(_externalSphere);
    }

    public void SphereUpScale(){
        _upScale = true;
    }
}
